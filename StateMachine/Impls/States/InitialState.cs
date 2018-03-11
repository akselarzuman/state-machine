using StateMachine.Models.Base;

namespace StateMachine.TestClient.Impls.States
{
    public class InitialState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Initial state executed.");
        }
    }
}