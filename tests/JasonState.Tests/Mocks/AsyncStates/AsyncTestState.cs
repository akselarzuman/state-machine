using System;
using System.Threading.Tasks;
using JasonState.Models;

namespace JasonState.Tests.Mocks.AsyncStates
{
    public class AsyncTestState : AsyncBaseState<MockContextModel>
    {
        public AsyncTestState()
        {
            ErrorState = "JasonState.Tests.Mocks.AsyncStates.AsyncErrorState";
        }
        
        public override Task ExecuteAsync(MockContextModel context)
        {
            throw new Exception();
        }
    }
}