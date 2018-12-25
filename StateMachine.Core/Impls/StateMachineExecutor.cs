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

            while (state != null && state.NextState != null)
            {
                string nextStateName = string.Empty;

                try
                {
                    state.Execute();

                    nextStateName = GetNextState(state.NextState);
                }
                catch
                {
                    nextStateName = state.ErrorState;
                }

                state = string.IsNullOrEmpty(nextStateName)
                            ? null
                            : machine.First(m => m.Name == nextStateName);
            }

            state?.Execute();
        }

        private string GetNextState(NextState[] nextStates)
        {
            foreach (var nextState in nextStates)
            {
                string expression = ParseExpression(nextState.Condition);

                bool isNextState = StateMachineContext.Context.CompileGeneric<bool>(expression).Evaluate();

                if (isNextState)
                {
                    return nextState.State;
                }
            }

            return string.Empty;
        }

        private string ParseExpression(string expression) => expression
                                                                .Replace("&&", "AND")
                                                                .Replace("&", "AND")
                                                                .Replace("|", "OR")
                                                                .Replace("||", "OR")
                                                                .Replace("!=", "<>")
                                                                .Replace("==", "=");
    }
}