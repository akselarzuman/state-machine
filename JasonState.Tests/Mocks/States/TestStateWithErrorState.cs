using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    public class TestStateWithErrorState : BaseState
    {
        public TestStateWithErrorState()
        {
            ErrorState = "JasonState.Tests.Mocks.States.ErrorState";
            NextState = new NextState[]
            {
                new NextState
                {
                    State = "JasonState.Tests.Mocks.States.ErrorState"
                }
            };
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}