using System.Collections.Generic;
using JasonState.Models;

namespace JasonState.Interfaces
{
    public interface IStateMachine<T> where T : class, new()
    {
        IEnumerable<BaseState<T>> BuildMachine(string path);

        void Execute(IEnumerable<BaseState<T>> states, T context);
    }
}