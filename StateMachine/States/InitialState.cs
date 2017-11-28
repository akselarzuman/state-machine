using StateMachine.Entities.Base;

namespace StateMachine.States
{
    public class InitialState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Initial state executed.");
        }
    }
}