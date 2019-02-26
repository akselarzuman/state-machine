using System;
using JasonState.Models;

namespace JasonState.Tests.Mocks.States
{
    internal class NotImplementedState : BaseState
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}