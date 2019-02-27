using System.Reflection;
using JasonState.Interfaces;

namespace JasonState
{
    public class AssemblyProvider : IAssemblyProvider
    {
        public Assembly GetEntryAssembly()
        {
            return Assembly.GetEntryAssembly();
        }
    }
}