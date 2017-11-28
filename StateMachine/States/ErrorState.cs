using StateMachine.Entities.Base;

namespace StateMachine.States
{
    public class ErrorState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Error state executed.");
        }
    }
}