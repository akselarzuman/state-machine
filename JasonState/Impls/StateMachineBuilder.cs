using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using JasonState.Interfaces;
using JasonState.Models;

namespace JasonState.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        private readonly string assemblyName;

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
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            StateMachineContext.Context.Imports.AddType(type, type.Name);
        }

        public void AddToContext(IEnumerable<Type> types)
        {
            if (types == null || !types.Any())
            {
                throw new ArgumentNullException(nameof(types));
            }

            foreach (var type in types)
            {
                AddToContext(type);
            }
        }
    }
}