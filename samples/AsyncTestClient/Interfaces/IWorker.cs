using System.Collections.Generic;
using System.Threading.Tasks;
using JasonState.Models;

namespace AsyncTestClient.Interfaces
{
    public interface IWorker<T>  where T : class, new()
    {        
        Task<IEnumerable<AsyncBaseState<T>>> BuildStateMachineAsync();

        Task ExecuteAsync(IEnumerable<AsyncBaseState<T>> machine, T context);
    }
}