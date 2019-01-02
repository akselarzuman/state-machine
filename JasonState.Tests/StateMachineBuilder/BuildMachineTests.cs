using System.IO;
using System.Linq;
using JasonState.Exceptions;
using Xunit;

namespace JasonState.Tests.StateMachineBuilder
{
    public class BuildMachineTests
    {
        private readonly Impls.StateMachineBuilder _stateMachineBuilder;

        public BuildMachineTests()
        {
            _stateMachineBuilder = new Impls.StateMachineBuilder();
        }

        [Fact]
        public void Should_Throw_ParameterRequiredException()
        {
            Assert.Throws<ParameterRequiredException>(() => _stateMachineBuilder.BuildMachine(null));
            Assert.Throws<ParameterRequiredException>(() => _stateMachineBuilder.BuildMachine(string.Empty));
        }

        [Fact]
        public void Should_Throw_FileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => _stateMachineBuilder.BuildMachine("State.json"));
        }

        [Fact]
        public void Should_Throw_InvalidJsonException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/Wrong.json");
            Assert.Throws<InvalidJsonException>(() => _stateMachineBuilder.BuildMachine(path));
        }

        [Fact]
        public void Should_Throw_StateNotFoundException()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/InvalidStates.json");
            Assert.Throws<StateNotFoundException>(() => _stateMachineBuilder.BuildMachine(path));
        }

        //[Fact]
        //public void Should_Build_Machine()
        //{
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/StateMachine.json");
        //    var machine = _stateMachineBuilder.BuildMachine(path);

        //    Assert.NotNull(machine);
        //    Assert.NotEmpty(machine);
        //    Assert.Single(machine);
        //}
    }
}