using System;
using System.Collections.Generic;
using JasonState.Tests.Mocks;
using Xunit;

namespace JasonState.Tests.StateMachineBuilder
{
    public class AddToContextTests
    {
        private readonly Impls.StateMachineBuilder _stateMachineBuilder;

        public AddToContextTests()
        {
            _stateMachineBuilder = new Impls.StateMachineBuilder();
        }
        
        
        [Fact]
        public void Should_Add_Type_To_Context()
        {
            _stateMachineBuilder.AddToContext(typeof(MockModel));
        }
        
        [Fact]
        public void Should_Add_Types_To_Context()
        {
            List<Type> types = new List<Type>
            {
                typeof(MockModel)
            };
            
            _stateMachineBuilder.AddToContext(types);
        }
    }
}