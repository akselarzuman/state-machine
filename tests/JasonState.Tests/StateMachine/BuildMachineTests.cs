using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JasonState.Exceptions;
using JasonState.Interfaces;
using JasonState.Tests.Mocks;
using Xunit;

namespace JasonState.Tests.StateMachine
{
    public class BuildMachineTests
    {
        private readonly IStateMachine<MockContextModel> _stateMachine = new JasonState.StateMachine<MockContextModel>(new MockAssemblyProvider());

        [Fact]
        public void Should_Throw_ArgumentException_When_Path_IsEmpty()
        {
            Assert.Throws<ArgumentException>(() => _stateMachine.BuildMachine(string.Empty));
        }
        
        [Fact]
        public void Should_Throw_ArgumentNullException_When_Path_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _stateMachine.BuildMachine(null));
        }

        [Fact]
        public void Should_Throw_FileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => _stateMachine.BuildMachine("State.json"));
        }

        [Fact]
        public void Should_Throw_InvalidJsonException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/Wrong.json");
            Assert.Throws<InvalidJsonException>(() => _stateMachine.BuildMachine(path));
        }

        [Fact]
        public void Should_Throw_ArgumentNullException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/InvalidStates.json");
            Assert.Throws<ArgumentNullException>(() => _stateMachine.BuildMachine(path));
        }

        [Fact]
        public void Should_Build_Machine()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/StateMachine.json");
            var machine = _stateMachine.BuildMachine(path);

            Assert.NotNull(machine);
            Assert.NotEmpty(machine);
            Assert.Single(machine);
        }
    }
}