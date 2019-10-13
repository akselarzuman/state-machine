using System.Collections.Generic;
using System.Threading.Tasks;
using JasonState.Models;

namespace JasonState.Interfaces
{
    public interface IAsyncStateMachine<T> where T : class, new()
    {
        Task<IEnumerable<AsyncBaseState<T>>> BuildMachineAsync(string path);

        Task ExecuteAsync(IEnumerable<AsyncBaseState<T>> states, T context);
    }
}