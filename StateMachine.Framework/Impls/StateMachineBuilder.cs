using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using StateMachine.Framework.Interfaces;
using StateMachine.Models;
using StateMachine.Models.Base;

namespace StateMachine.Framework.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        public Models.StateMachine Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            
            using (var file = File.OpenText(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                return (Models.StateMachine) jsonSerializer.Deserialize(file, typeof(Models.StateMachine));
            }
        }

        public IEnumerable<BaseState> BuildMachine(Models.StateMachine stateMachine)
        {
            if (stateMachine?.States == null || !stateMachine.States.Any())
            {
                return null;
            }

            return stateMachine.States.Select(CreateState).ToList();
        }

        private BaseState CreateState(State state)
        {
            string fullClassName = $"{state.Namespace}.{state.Name}";
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            var baseState = (BaseState) Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState?[0]?.State;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
    }
}