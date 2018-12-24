using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using StateMachine.Core.Interfaces;
using StateMachine.Core.Models;

namespace StateMachine.Core.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        private string assemblyName;

        public StateMachineBuilder()
        {
            assemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        public StateMachineModel Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            using (var file = File.OpenText(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                return (StateMachineModel)jsonSerializer.Deserialize(file, typeof(StateMachineModel));
            }
        }

        public IEnumerable<BaseState> BuildMachine(StateMachineModel stateMachine)
        {
            if (stateMachine?.States == null || !stateMachine.States.Any())
            {
                return null;
            }

            return stateMachine.States.Select(CreateState).ToList();
        }

        private BaseState CreateState(StateModel state)
        {
            string fullClassName = $"{state.Namespace}.{state.Name}";
            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            var baseState = (BaseState)Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }

        public void AddToContext(Type type)
        {
            StateMachineContext.Context.Imports.AddType(type, type.Name);
        }

        public void AddToContext(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                AddToContext(type);
            }
        }
    }
}