using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnsureDotnet;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;

namespace JasonState
{
    public class AsyncStateMachine<T> : IAsyncStateMachine<T> where T : class, new()
    {
        private readonly string _assemblyName;

        public AsyncStateMachine(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        public AsyncStateMachine(IAssemblyProvider assemblyProvider)
        {
            _assemblyName = assemblyProvider.GetEntryAssembly().GetName().Name;
        }

        public async Task<IEnumerable<AsyncBaseState<T>>> BuildMachineAsync(string path)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            StateMachineModel stateMachine;

            using (var reader = new StreamReader(path))
            {
                string json = await reader.ReadToEndAsync();
                stateMachine = Load(json);
            }

            Ensure.ArgumentNotNullOrEmptyEnumerable(stateMachine?.States, string.Empty);

            return stateMachine.States.Select(CreateState).ToList();
        }

        private StateMachineModel Load(string json)
        {
            Ensure.ArgumentNotNullOrEmptyString(json, nameof(json));

            try
            {
                return JsonConvert.DeserializeObject<StateMachineModel>(json);
            }
            catch (JsonReaderException ex)
            {
                throw new InvalidJsonException("Given Json is in incorrect format.", ex);
            }
            catch
            {
                throw;
            }
        }

        public async Task ExecuteAsync(IEnumerable<AsyncBaseState<T>> states, T context)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(states, nameof(states));

            var state = states.First();

            try
            {
                while (state?.NextState != null)
                {
                    await state.ExecuteAsync(context);
                    string nextStateName = await GetNextStateAsync(state.NextState, context);

                    state = string.IsNullOrEmpty(nextStateName)
                        ? null
                        : states.First(m => m.Name == nextStateName);
                }

                await state?.ExecuteAsync(context);
            }
            catch (Exception ex)
            {
                string nextStateName = state.ErrorState;

                if (!string.IsNullOrEmpty(nextStateName))
                {
                    state = states.FirstOrDefault(m => m.Name == nextStateName);

                    await state?.ExecuteAsync(context);
                }
            }
        }

        private AsyncBaseState<T> CreateState(StateModel state)
        {
            Ensure.ArgumentNotNull(state, nameof(state));

            var fullClassName = $"{state.Namespace}.{state.Name}";
            var type = Type.GetType($"{fullClassName},{_assemblyName}");

            Ensure.ArgumentNotNull(type, $"{fullClassName} can not be initiated");

            var baseState = (AsyncBaseState<T>) Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }

        private async Task<string> GetNextStateAsync(NextState[] nextStates, T context)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(nextStates, string.Empty);

            foreach (NextState nextState in nextStates)
            {
                ScriptRunner<bool> script =
                    CSharpScript.Create<bool>(nextState.Condition, globalsType: typeof(T))
                        .CreateDelegate();
                bool isNextState = await script(context);

                if (isNextState)
                {
                    return nextState.State;
                }
            }

            return string.Empty;
        }
    }
}