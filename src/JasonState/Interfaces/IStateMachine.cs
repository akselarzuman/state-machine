using System;
using System.Collections.Generic;
using JasonState.Models;

namespace JasonState.Interfaces
{
    public interface IStateMachine<T> where T : class, new()
    {
        IEnumerable<BaseState<T>> BuildMachine(string path);

        void AddToContext(Type type);

        void AddToContext(IEnumerable<Type> types);

        void Execute(IEnumerable<BaseState<T>> states, T context);
    }
}