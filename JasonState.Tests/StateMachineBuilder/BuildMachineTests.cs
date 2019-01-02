using System.IO;
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
    }
}