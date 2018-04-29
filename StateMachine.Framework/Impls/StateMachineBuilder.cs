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
        private string assemblyName;

        public StateMachineBuilder()
        {
            assemblyName = Assembly.GetEntryAssembly().GetName().Name; 
        }

        public Models.StateMachine Load(string path)
        {
            using (var file = File.OpenText(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                return (Models.StateMachine) jsonSerializer.Deserialize(file, typeof(Models.StateMachine));
            }
        }

        public IList<BaseState> BuildMachine(Models.StateMachine stateMachine)
        {
            List<BaseState> machine = null;

            if (stateMachine?.States != null && stateMachine.States.Any())
            {
                machine = new List<BaseState>();

                foreach (var state in stateMachine.States)
                {
                    BaseState baseState = CreateState(state);

                    machine.Add(baseState);
                }
            }

            return machine;
        }

        private BaseState CreateState(State state)
        {
            string fullClassName = $"{state.Namespace}.{state.Name}";
            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            BaseState baseState = (BaseState) Activator.CreateInstance(type);
            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState?[0]?.State;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
    }
}