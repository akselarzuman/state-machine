using System;
using System.Collections.Generic;
using JasonState.Models;

namespace TestClient.Interfaces
{
    public interface IWorker
    {
        StateMachineModel LoadStateMachine();
        
        IEnumerable<BaseState> BuildStateMachine(StateMachineModel stateMachine);

        void AddToContext(Type type);

        void Execute(IEnumerable<BaseState> machine);
    }
}