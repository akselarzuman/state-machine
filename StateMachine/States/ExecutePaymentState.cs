using StateMachine.Entities.Base;

namespace StateMachine.States
{
    public class ExecutePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Execute Payment state executed.");
        }
    }
}