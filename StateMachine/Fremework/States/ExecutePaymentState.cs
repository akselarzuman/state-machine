using StateMachine.Fremework.Base;

namespace StateMachine.Fremework.States
{
    public class ExecutePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Execute Payment state executed.");
        }
    }
}