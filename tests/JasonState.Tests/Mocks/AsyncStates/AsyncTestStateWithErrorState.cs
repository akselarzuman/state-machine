using System.Threading.Tasks;
using JasonState.Models;

namespace JasonState.Tests.Mocks.AsyncStates
{
    public class AsyncTestStateWithErrorState : AsyncBaseState<MockContextModel>
    {
        public AsyncTestStateWithErrorState()
        {
            ErrorState = "JasonState.Tests.Mocks.AsyncStates.AsyncErrorState";
            NextState = new NextState[]
            {
                new NextState
                {
                    State = "JasonState.Tests.Mocks.AsyncStates.AsyncErrorState"
                }
            };
        }
        
        public override Task ExecuteAsync(MockContextModel context)
        {
            throw new System.NotImplementedException();
        }
    }
}