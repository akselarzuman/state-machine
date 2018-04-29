﻿using System.Collections.Generic;
using System.IO;
using StateMachine.Framework.Interfaces;
using StateMachine.Models.Base;
using StateMachine.TestClient.Interfaces;

namespace StateMachine.TestClient.Impls
{
    public class Worker : IWorker
    {
        private readonly IStateMachineBuilder _stateMachineBuilder;
        private readonly IStateMachineExecutor _stateMachineExecutor;

        public Worker(IStateMachineBuilder stateMachineBuilder, IStateMachineExecutor stateMachineExecutor)
        {
            _stateMachineBuilder = stateMachineBuilder;
            _stateMachineExecutor = stateMachineExecutor;
        }

        public Models.StateMachineModel LoadStateMachine()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Files/StateMachine.json");
            
            return _stateMachineBuilder.Load(path);
        }

        public IList<BaseState> BuildStateMachine(Models.StateMachineModel stateMachine)
        {
            return _stateMachineBuilder.BuildMachine(stateMachine);
        }

        public void Execute(IList<BaseState> machine)
        {
            _stateMachineExecutor.Execute(machine);
        }
    }
}