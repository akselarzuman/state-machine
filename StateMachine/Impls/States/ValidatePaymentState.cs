using StateMachine.Core.Models;

namespace StateMachine.TestClient.Impls.States
{
    public class ValidatePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Validate Payment state executed.");
        }
    }
}