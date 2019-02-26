using System;
using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    public class TestState : BaseState
    {
        public TestState()
        {
            ErrorState = "JasonState.Tests.Mocks.States.ErrorState";
        }
        
        public override void Execute()
        {
            throw new Exception();
        }
    }
}