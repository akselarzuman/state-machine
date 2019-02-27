using System.Reflection;

namespace JasonState.Interfaces
{
    public interface IAssemblyProvider
    {
        Assembly GetEntryAssembly();
    }
}