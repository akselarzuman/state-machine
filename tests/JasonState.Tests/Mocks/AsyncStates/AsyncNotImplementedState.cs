using System;
using System.Threading.Tasks;
using JasonState.Models;

namespace JasonState.Tests.Mocks.AsyncStates
{
    internal class AsyncNotImplementedState : AsyncBaseState<MockContextModel>
    {
        public override Task ExecuteAsync(MockContextModel context)
        {
            throw new NotImplementedException();
        }
    }
}