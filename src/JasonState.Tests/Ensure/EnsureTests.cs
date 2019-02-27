using System;
using System.Collections.Generic;
using JasonState.Exceptions;
using Xunit;

namespace JasonState.Tests.Ensure
{
    public class EnsureTests
    {
        [Fact]
        public void Should_Throw_ParameterRequiredException()
        {
            Assert.Throws<ParameterRequiredException>(() => JasonState.Ensure.NotNull(null as string, nameof(string.Empty)));
            Assert.Throws<ParameterRequiredException>(() => JasonState.Ensure.NotNullOrEmptyString(null as string, nameof(string.Empty)));
            Assert.Throws<ParameterRequiredException>(() => JasonState.Ensure.NotEmptyList(null as List<string>, nameof(string.Empty)));
            Assert.Throws<ParameterRequiredException>(() => JasonState.Ensure.NotEmptyList(new List<string>(), nameof(string.Empty)));
            Assert.Throws<StateNotFoundException>(() => JasonState.Ensure.IsValidType(null as Type, nameof(string.Empty)));
        }

        [Fact]
        public void Should_Not_Throw_ParameterRequiredException()
        {
            JasonState.Ensure.NotNull("test", nameof(string.Empty));
            JasonState.Ensure.NotNullOrEmptyString("test", nameof(string.Empty));
            JasonState.Ensure.NotEmptyList(new List<string> {"test"}, nameof(string.Empty));
            JasonState.Ensure.IsValidType(typeof(string), nameof(string.Empty));
        }
    }
}