using System;

namespace JasonState.Exceptions
{
    public class InvalidJsonException : Exception
    {
        public InvalidJsonException()
        {
        }

        public InvalidJsonException(string message) : base(message)
        {
        }

        public InvalidJsonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}