using System.Linq;
using System.Collections.Generic;
using StateMachine.Models.Base;
using StateMachine.Fremework.Interfaces;

namespace StateMachine.Fremework.Impls
{
    public class StateMachineExecutor : IStateMachineExecutor
    {
        public void Execute(IList<BaseState> machine)
        {
            if (machine != null && machine.Any())
            {
                var state = machine.First();

                while (state != null && !string.IsNullOrEmpty(state.NextState))
                {
                    state.Execute();

                    string nextStateName = state.NextState;

                    state = machine.First(m => m.Name == nextStateName);
                }

                if (state != null)
                {
                    state.Execute();
                }
            }
        }
    }
}