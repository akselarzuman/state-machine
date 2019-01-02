using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public IEnumerable<BaseState> BuildMachine(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            StateMachineModel stateMachine = Load(path);

            if (stateMachine?.States == null || !stateMachine.States.Any())
            {
                return null;
            }

            return stateMachine.States.Select(CreateState).ToList();
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

        private StateMachineModel Load(string path)
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

        private BaseState CreateState(StateModel state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            string fullClassName = $"{state.Namespace}.{state.Name}";
            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            var baseState = (BaseState)Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
    }
}