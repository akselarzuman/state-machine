using System;
using System.Collections.Generic;
using JasonState.Exceptions;
using JasonState.Models;
using JasonState.Tests.Mocks.States;
using Xunit;

namespace JasonState.Tests.StateMachineExecutor
{
    public class ExecuteTests
    {
        private readonly Impls.StateMachineExecutor _stateMachineExecutor;

        public ExecuteTests()
        {
            _stateMachineExecutor = new Impls.StateMachineExecutor();
        }

        [Fact]
        public void Should_Throw_ParameterRequiredException()
        {
            Assert.Throws<ParameterRequiredException>(() => _stateMachineExecutor.Execute(null as List<BaseState>));
        }

//        [Fact]
//        public void Should_Throw_NotImplementedException()
//        {
//            var states = new List<BaseState>
//            {
//                new NotImplementedState()
//            };
//            
//            Assert.Throws<NotImplementedException>(() => _stateMachineExecutor.Execute(states));
//        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_NextState_Is_Null()
        {
            var states = new List<BaseState>
            {
                new TestState()
            };
            
            _stateMachineExecutor.Execute(states);
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_Execute_ErrorState()
        {
            var states = new List<BaseState>
            {
                new TestStateWithErrorState(),
                new ErrorState()
            };
            
            _stateMachineExecutor.Execute(states);
        }
        
        
    }
}