using System;

namespace JasonState.Exceptions
{
    public class ParameterRequiredException : Exception
    {
        public ParameterRequiredException()
        {
        }

        public ParameterRequiredException(string message) : base(message)
        {
        }

        public ParameterRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}