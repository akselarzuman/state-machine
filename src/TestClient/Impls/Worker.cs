using System;
using System.Collections.Generic;
using System.IO;
using JasonState.Interfaces;
using JasonState.Models;
using TestClient.Interfaces;

namespace TestClient.Impls
{
    public class Worker : IWorker
    {
        private readonly IStateMachine _stateMachine;

        public Worker(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public IEnumerable<BaseState> BuildStateMachine()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/StateMachine.json");
            return _stateMachine.BuildMachine(path);
        }

        public void AddToContext(Type type)
        {
            _stateMachine.AddToContext(type);
        }

        public void Execute(IEnumerable<BaseState> machine)
        {
            _stateMachine.Execute(machine);
        }
    }
}