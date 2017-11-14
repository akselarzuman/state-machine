using System;
using System.Reflection;
using StateMachine.Fremework.Base;
using StateMachine.Fremework.Interfaces;
using System.Linq;

namespace StateMachine.Fremework.Impls
{
    public class StateMachineExecutor : IStateMachineExecutor
    {

        public void Run(Entities.StateMachine stateMachine)
        {
            if (stateMachine.States.Any())
            {
                Run(GetState(stateMachine.States[0].Namespace, stateMachine.States[0].Name));
            }
        }

        public void Run(BaseState state)
        {
            try
            {
                state.Execute();

                var nextState = GetState(state);

                if (nextState != null && nextState.NextState != null && !string.IsNullOrEmpty(nextState.NextState.Trim()))
                {
                    Run(GetState(nextState.Namespace, nextState.NextState));
                }
            }
            catch
            {
                var nextState = GetState(state);

                Run(GetState(nextState.Namespace, nextState.ErrorState));
            }
        }

        private BaseState GetState(string @namespace, string name)
        {
            return (BaseState)Activator.CreateInstance(Type.GetType($"{@namespace}.{name},{Assembly.GetExecutingAssembly().GetName().Name}"));
        }

        private Entities.State GetState(BaseState state)
        {
            var stateName = state.ToString().Substring(state.ToString().LastIndexOf(".") + 1, state.ToString().Length - 1 - state.ToString().LastIndexOf("."));

            return Constant.States.FirstOrDefault(m => m.Name == stateName);
        }
    }
}