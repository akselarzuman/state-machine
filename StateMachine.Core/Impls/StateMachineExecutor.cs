using System.Collections.Generic;
using System.Linq;
using StateMachine.Core.Interfaces;
using StateMachine.Core.Models;

namespace StateMachine.Core.Impls
{
    public class StateMachineExecutor : IStateMachineExecutor
    {
        public void Execute(IEnumerable<BaseState> machine)
        {
            if (machine == null || !machine.Any())
            {
                return;
            }
            
            var state = machine.First();

            while (state != null && !string.IsNullOrEmpty(state.NextState))
            {
                state.Execute();

                string nextStateName = state.NextState;

                state = machine.First(m => m.Name == nextStateName);
            }

            state?.Execute();
        }
    }
}