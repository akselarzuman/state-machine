using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JasonState.Interfaces;
using JasonState.Models;
using JasonState.Tests.Mocks;
using JasonState.Tests.Mocks.AsyncStates;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class ExecuteAsyncTests
    {
        private readonly IAsyncStateMachine<MockContextModel> _stateMachine = new JasonState.AsyncStateMachine<MockContextModel>(new AssemblyProvider());

        [Fact]
        public void Should_Throw_ArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _stateMachine.ExecuteAsync(null as List<AsyncBaseState<MockContextModel>>, new MockContextModel()));
        }

        [Fact]
        public async Task Should_Not_Throw_NotImplementedException()
        {
            var states = new List<AsyncBaseState<MockContextModel>>
            {
                new AsyncNotImplementedState()
            };
            
            await _stateMachine.ExecuteAsync(states, new MockContextModel());
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_NextState_Is_Null()
        {
            var states = new List<AsyncBaseState<MockContextModel>>
            {
                new AsyncTestState()
            };
            
            _stateMachine.ExecuteAsync(states, new MockContextModel());
        }
        
        [Fact]
        public void Should_Execute_StateWithException_And_Execute_ErrorState()
        {
            var states = new List<AsyncBaseState<MockContextModel>>
            {
                new AsyncTestStateWithErrorState(),
                new AsyncErrorState()
            };
            
            _stateMachine.ExecuteAsync(states, new MockContextModel());
        }
    }
}