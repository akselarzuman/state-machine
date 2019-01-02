using System.Collections.Generic;
using System.Linq;
using JasonState.Exceptions;

namespace JasonState
{
    public static class Ensure
    {
        public static void NotNull(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            throw new ParameterRequiredException(name);
        }

        public static void NotNullOrEmptyString(string value, string name)
        {
            NotNull(value, name);

            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            throw new ParameterRequiredException(name);
        }

        public static void NotEmptyList(IEnumerable<object> value, string name)
        {
            NotNull(value, name);

            if (value.Any())
            {
                return;
            }

            throw new ParameterRequiredException(name);
        }
    }
}