using StateMachine.Fremework.Base;

namespace StateMachine.Fremework.States
{
    public class InitialState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Initial state executed.");
        }
    }
}