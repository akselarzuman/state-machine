using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;
using StateMachine.Models;
using StateMachine.Models.Base;
using StateMachine.Fremework.Interfaces;

namespace StateMachine.Fremework.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        public Models.StateMachine Load(string path)
        {
            using (var file = File.OpenText(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                return (Models.StateMachine)jsonSerializer.Deserialize(file, typeof(Models.StateMachine));
            }
        }

        public IList<BaseState> BuildMachine(Models.StateMachine stateMachine)
        {
            List<BaseState> machine = null;

            if (stateMachine != null && stateMachine.States != null && stateMachine.States.Any())
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

            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;

            Type type = Type.GetType($"{fullClassName},{assemblyName}");

            BaseState baseState = (BaseState)Activator.CreateInstance(type);

            baseState.Name = state.Name;
            baseState.Namespace = state.Namespace;
            baseState.NextState = state.NextState;
            baseState.ErrorState = state.ErrorState;

            return baseState;
        }
    }
}