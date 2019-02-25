using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using Newtonsoft.Json;

namespace JasonState.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        private readonly string assemblyName;

        public StateMachineBuilder()
        {
            assemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        public StateMachineBuilder(IAssemblyProvider assemblyProvider)
        {
            assemblyName = assemblyProvider.GetEntryAssembly().GetName().Name;
        }

        public IEnumerable<BaseState> BuildMachine(string path)
        {
            Ensure.NotNullOrEmptyString(path, nameof(path));

            StateMachineModel stateMachine = Load(path);

            Ensure.NotEmptyList(stateMachine?.States, string.Empty);

            return stateMachine.States.Select(CreateState).ToList();
        }

        public void AddToContext(Type type)
        {
            Ensure.NotNull(type, nameof(type));

            StateMachineContext.Context.Imports.AddType(type, type.Name);
        }

        public void AddToContext(IEnumerable<Type> types)
        {
            Ensure.NotEmptyList(types, nameof(types));

            foreach (var type in types)
            {
                AddToContext(type);
            }
        }

        private StateMachineModel Load(string path)
        {
            Ensure.NotNullOrEmptyString(path, nameof(path));

            using (var file = File.OpenText(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                try
                {
                    return (StateMachineModel)jsonSerializer.Deserialize(file, typeof(StateMachineModel));
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
            Ensure.NotNull(state, nameof(state));

            string fullClassName = $"{state.Namespace}.{state.Name}";
            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            Ensure.IsValidType(type, $"{fullClassName} can not be initiated");

            var baseState = (BaseState)Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
    }
}