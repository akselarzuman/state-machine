using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnsureDotnet;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;

namespace JasonState
{
    public class StateMachine<T> : IStateMachine<T> where T : class, new()
    {
        private readonly string _assemblyName;

        public StateMachine(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        public StateMachine(IAssemblyProvider assemblyProvider)
        {
            _assemblyName = assemblyProvider.GetEntryAssembly().GetName().Name;
        }

        public IEnumerable<BaseState<T>> BuildMachine(string path)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            StateMachineModel stateMachine = Load(path);

            Ensure.ArgumentNotNullOrEmptyEnumerable(stateMachine?.States, string.Empty);

            return stateMachine.States.Select(CreateState).ToList();
        }

        public void Execute(IEnumerable<BaseState<T>> states, T context)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(states, nameof(states));

            var state = states.First();

            try
            {
                while (state?.NextState != null)
                {
                    state.Execute(context);
                    string nextStateName = GetNextState(state.NextState, context);

                    state = string.IsNullOrEmpty(nextStateName)
                        ? null
                        : states.First(m => m.Name == nextStateName);
                }

                state?.Execute(context);
            }
            catch (Exception ex)
            {
                string nextStateName = state.ErrorState;

                if (!string.IsNullOrEmpty(nextStateName))
                {
                    state = states.FirstOrDefault(m => m.Name == nextStateName);

                    state?.Execute(context);
                }
            }
        }

        private StateMachineModel Load(string path)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (var file = File.OpenText(path))
            {
                var jsonSerializer = new JsonSerializer();

                try
                {
                    return (StateMachineModel) jsonSerializer.Deserialize(file, typeof(StateMachineModel));
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
        }

        private BaseState<T> CreateState(StateModel state)
        {
            Ensure.ArgumentNotNull(state, nameof(state));

            var fullClassName = $"{state.Namespace}.{state.Name}";
            var type = Type.GetType($"{fullClassName},{_assemblyName}");

            Ensure.ArgumentNotNull(type, $"{fullClassName} can not be initiated");

            var baseState = (BaseState<T>) Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }

        private string GetNextState(NextState[] nextStates, T context)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(nextStates, string.Empty);

            foreach (NextState nextState in nextStates)
            {
                ScriptRunner<bool> script =
                    CSharpScript.Create<bool>(nextState.Condition, globalsType: typeof(T))
                        .CreateDelegate();
                bool isNextState = script(context).GetAwaiter().GetResult();

                if (isNextState)
                {
                    return nextState.State;
                }
            }

            return string.Empty;
        }
    }
}