using System;
using System.Collections.Generic;
using JasonState.Models;

namespace TestClient.Interfaces
{
    public interface IWorker<T>  where T : class, new()
    {        
        IEnumerable<BaseState<T>> BuildStateMachine();

        void AddToContext(Type type);

        void Execute(IEnumerable<BaseState<T>> machine, T context);
    }
}