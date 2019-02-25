using System;
using System.Reflection;
using JasonState.Interfaces;

namespace JasonState.Impls
{
    public class AssemblyProvider : IAssemblyProvider
    {
        public Assembly GetEntryAssembly()
        {
            return Assembly.GetEntryAssembly();
        }
    }
}