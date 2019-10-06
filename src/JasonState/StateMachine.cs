using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnsureDotnet;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using Newtonsoft.Json;

namespace JasonState
{
    public class StateMachine : IStateMachine
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

        public IEnumerable<BaseState> BuildMachine(string path)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            StateMachineModel stateMachine = Load(path);

            Ensure.ArgumentNotNullOrEmptyEnumerable(stateMachine?.States, string.Empty);

            return stateMachine.States.Select(CreateState).ToList();
        }

        public void AddToContext(Type type)
        {
            Ensure.ArgumentNotNull(type, nameof(type));

            StateMachineContext.Context.Imports.AddType(type, type.Name);
        }

        public void AddToContext(IEnumerable<Type> types)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(types, nameof(types));

            foreach (var type in types)
            {
                AddToContext(type);
            }
        }

        public void Execute(IEnumerable<BaseState> states)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(states, nameof(states));

            var state = states.First();

            try
            {
                while (state?.NextState != null)
                {
                    state.Execute();
                    string nextStateName = GetNextState(state.NextState);

                    state = string.IsNullOrEmpty(nextStateName)
                                ? null
                                : states.First(m => m.Name == nextStateName);
                }

                state?.Execute();
            }
            catch
            {
                string nextStateName = state.ErrorState;

                if (!string.IsNullOrEmpty(nextStateName))
                {
                    state = states.FirstOrDefault(m => m.Name == nextStateName);

                    state?.Execute();
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

        private BaseState CreateState(StateModel state)
        {
            Ensure.ArgumentNotNull(state, nameof(state));

            var fullClassName = $"{state.Namespace}.{state.Name}";
            var type = Type.GetType($"{fullClassName},{_assemblyName}");

            Ensure.ArgumentNotNull(type, $"{fullClassName} can not be initiated");

            var baseState = (BaseState) Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
        
        private string GetNextState(NextState[] nextStates)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(nextStates, string.Empty);

            foreach (var nextState in nextStates)
            {
                string expression = ParseExpression(nextState.Condition);
                bool isNextState = StateMachineContext.Context.CompileGeneric<bool>(expression).Evaluate();

                if (isNextState)
                {
                    return nextState.State;
                }
            }

            return string.Empty;
        }

        private string ParseExpression(string expression)
        {
            Ensure.ArgumentNotNullOrEmptyString(expression, nameof(expression));

            return expression
                        .Replace("&&", "AND")
                        .Replace("&", "AND")
                        .Replace("|", "OR")
                        .Replace("||", "OR")
                        .Replace("!=", "<>")
                        .Replace("==", "=");
        }
    }
}