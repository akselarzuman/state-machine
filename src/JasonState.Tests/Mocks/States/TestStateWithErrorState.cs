using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    public class TestStateWithErrorState : BaseState<MockContextModel>
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
        
        public override void Execute(MockContextModel context)
        {
            throw new System.NotImplementedException();
        }
    }
}