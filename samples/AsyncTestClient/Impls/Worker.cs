using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AsyncTestClient.Interfaces;
using JasonState.Interfaces;
using JasonState.Models;

namespace AsyncTestClient.Impls
{
    public class Worker<T> : IWorker<T> where T : class, new()
    {
        private readonly IAsyncStateMachine<T> _stateMachine;

        public Worker(IAsyncStateMachine<T> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public Task<IEnumerable<AsyncBaseState<T>>> BuildStateMachineAsync()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/StateMachine.json");
            return _stateMachine.BuildMachineAsync(path);
        }

        public async Task ExecuteAsync(IEnumerable<AsyncBaseState<T>> machine, T context)
        {
            await _stateMachine.ExecuteAsync(machine, context);
        }
    }
}