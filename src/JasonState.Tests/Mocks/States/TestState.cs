using System;
using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    public class TestState : BaseState<MockContextModel>
    {
        public TestState()
        {
            ErrorState = "JasonState.Tests.Mocks.States.ErrorState";
        }
        
        public override void Execute(MockContextModel context)
        {
            throw new Exception();
        }
    }
}