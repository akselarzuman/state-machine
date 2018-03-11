using StateMachine.Models.Base;

namespace StateMachine.TestClient.Impls.States
{
    public class ExecutePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Execute Payment state executed.");
        }
    }
}