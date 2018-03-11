using StateMachine.Models.Base;

namespace StateMachine.TestClient.Impls.States
{
    public class FinalState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Final state executed.");
        }
    }
}