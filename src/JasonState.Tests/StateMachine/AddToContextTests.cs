using System;
using System.Collections.Generic;
using JasonState.Interfaces;
using JasonState.Tests.Mocks;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class AddToContextTests
    {
        private readonly IStateMachine _stateMachine = new JasonState.StateMachine(new AssemblyProvider());

        [Fact]
        public void Should_Add_Type_To_Context()
        {
            _stateMachine.AddToContext(typeof(MockModel));
        }

        [Fact]
        public void Should_Add_Types_To_Context()
        {
            var types = new List<Type>
            {
                typeof(MockModel)
            };

            _stateMachine.AddToContext(types);
        }
    }
}