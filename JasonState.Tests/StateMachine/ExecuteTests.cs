using System;
using System.Collections.Generic;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using JasonState.Tests.Mocks.States;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class ExecuteTests
    {
        private readonly IStateMachine _stateMachine = new JasonState.StateMachine();

        [Fact]
        public void Should_Throw_ParameterRequiredException()
        {
            Assert.Throws<ParameterRequiredException>(() => _stateMachine.Execute(null as List<BaseState>));
        }

        [Fact]
        public void Should_Not_Throw_NotImplementedException()
        {
            var states = new List<BaseState>
            {
                new NotImplementedState()
            };
            
            _stateMachine.Execute(states);
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_NextState_Is_Null()
        {
            var states = new List<BaseState>
            {
                new TestState()
            };
            
            _stateMachine.Execute(states);
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_Execute_ErrorState()
        {
            var states = new List<BaseState>
            {
                new TestStateWithErrorState(),
                new ErrorState()
            };
            
            _stateMachine.Execute(states);
        }
    }
}