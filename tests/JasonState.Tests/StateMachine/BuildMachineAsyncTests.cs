using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Tests.Mocks;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class BuildMachineAsyncTests
    {
        private readonly IAsyncStateMachine<MockContextModel> _stateMachine = new JasonState.AsyncStateMachine<MockContextModel>(new MockAssemblyProvider());

        [Fact]
        public void Should_Throw_ArgumentException_When_Path_IsEmpty()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _stateMachine.BuildMachineAsync(string.Empty));
        }
        
        [Fact]
        public void Should_Throw_ArgumentNullException_When_Path_IsNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _stateMachine.BuildMachineAsync(null));
        }

        [Fact]
        public void Should_Throw_FileNotFoundException()
        {
            Assert.ThrowsAsync<FileNotFoundException>(() => _stateMachine.BuildMachineAsync("State.json"));
        }

        [Fact]
        public void Should_Throw_InvalidJsonException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/Wrong.json");
            Assert.ThrowsAsync<InvalidJsonException>(() => _stateMachine.BuildMachineAsync(path));
        }

        [Fact]
        public void Should_Throw_ArgumentNullException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/InvalidStates.json");
            Assert.ThrowsAsync<ArgumentNullException>(() => _stateMachine.BuildMachineAsync(path));
        }

        [Fact]
        public async Task Should_Build_Machine()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/AsyncStateMachine.json");
            var machine = await _stateMachine.BuildMachineAsync(path);

            Assert.NotNull(machine);
            Assert.NotEmpty(machine);
            Assert.Single(machine);
        }
    }
}