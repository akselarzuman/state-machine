using Flee.PublicTypes;

namespace JasonState.Models
{
    internal static class StateMachineContext
    {
        public static ExpressionContext Context { get; set; } = new ExpressionContext();
    }
}