using System;
using System.Collections.Generic;
using System.IO;
using JasonState.Interfaces;
using JasonState.Models;
using TestClient.Interfaces;

namespace TestClient.Impls
{
    public class Worker<T> : IWorker<T> where T : class, new()
    {
        private readonly IStateMachine<T> _stateMachine;

        public Worker(IStateMachine<T> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public IEnumerable<BaseState<T>> BuildStateMachine()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/StateMachine.json");
            return _stateMachine.BuildMachine(path);
        }

        public void Execute(IEnumerable<BaseState<T>> machine, T context)
        {
            _stateMachine.Execute(machine, context);
        }
    }
}