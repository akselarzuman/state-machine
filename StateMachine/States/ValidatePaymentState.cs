using StateMachine.Entities.Base;

namespace StateMachine.States
{
    public class ValidatePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Validate Payment state executed.");
        }
    }
}