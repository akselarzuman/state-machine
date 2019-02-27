using System.Reflection;
using JasonState.Interfaces;

namespace JasonState.Tests.Mocks
{
    public class MockAssemblyProvider : IAssemblyProvider
    {
        public Assembly GetEntryAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}