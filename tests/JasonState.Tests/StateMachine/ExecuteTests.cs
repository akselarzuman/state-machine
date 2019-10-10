using System;
using System.Collections.Generic;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Models;
using JasonState.Tests.Mocks;
using JasonState.Tests.Mocks.States;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class ExecuteTests
    {
        private readonly IStateMachine<MockContextModel> _stateMachine = new JasonState.StateMachine<MockContextModel>(new AssemblyProvider());

        [Fact]
        public void Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stateMachine.Execute(null as List<BaseState<MockContextModel>>, new MockContextModel()));
        }

        [Fact]
        public void Should_Not_Throw_NotImplementedException()
        {
            var states = new List<BaseState<MockContextModel>>
            {
                new NotImplementedState()
            };
            
            _stateMachine.Execute(states, new MockContextModel());
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_NextState_Is_Null()
        {
            var states = new List<BaseState<MockContextModel>>
            {
                new TestState()
            };
            
            _stateMachine.Execute(states, new MockContextModel());
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_Execute_ErrorState()
        {
            var states = new List<BaseState<MockContextModel>>
            {
                new TestStateWithErrorState(),
                new ErrorState()
            };
            
            _stateMachine.Execute(states, new MockContextModel());
        }
    }
}