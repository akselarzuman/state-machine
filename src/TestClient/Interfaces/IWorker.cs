using System;
using System.Collections.Generic;
using JasonState.Models;

namespace TestClient.Interfaces
{
    public interface IWorker
    {        
        IEnumerable<BaseState> BuildStateMachine();

        void AddToContext(Type type);

        void Execute(IEnumerable<BaseState> machine);
    }
}