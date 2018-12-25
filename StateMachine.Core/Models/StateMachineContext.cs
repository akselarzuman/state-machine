using Flee.PublicTypes;

namespace StateMachine.Core.Models
{
    internal static class StateMachineContext
    {
        public static ExpressionContext Context { get; set; } = new ExpressionContext();
    }
}