using System.Collections.Generic;
using System.Linq;
using JasonState.Interfaces;
using JasonState.Models;

namespace JasonState.Impls
{
    public class StateMachineExecutor : IStateMachineExecutor
    {
        public void Execute(IEnumerable<BaseState> states)
        {
            Ensure.NotEmptyList(states, nameof(states));

            var state = states.First();

            while (state?.NextState != null)
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
                            : states.First(m => m.Name == nextStateName);
            }

            state?.Execute();
        }

        private string GetNextState(NextState[] nextStates)
        {
            Ensure.NotEmptyList(nextStates, string.Empty);

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

        private string ParseExpression(string expression)
        {
            Ensure.NotNullOrEmptyString(expression, nameof(expression));

            return expression
                         .Replace("&&", "AND")
                         .Replace("&", "AND")
                         .Replace("|", "OR")
                         .Replace("||", "OR")
                         .Replace("!=", "<>")
                         .Replace("==", "=");
        }
    }
}