using System.Threading.Tasks;
using JasonState.Models;

namespace JasonState.Tests.Mocks.AsyncStates
{
    public class AsyncErrorState : AsyncBaseState<MockContextModel>
    {
        public override Task ExecuteAsync(MockContextModel context)
        {
            return Task.CompletedTask;
        }
    }
}