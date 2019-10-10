using System;
using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    internal class NotImplementedState : BaseState<MockContextModel>
    {
        public override void Execute(MockContextModel context)
        {
            throw new NotImplementedException();
        }
    }
}