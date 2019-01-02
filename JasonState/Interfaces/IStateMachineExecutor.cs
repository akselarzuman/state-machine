using System.Collections.Generic;
using JasonState.Models;

namespace JasonState.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Execute(IEnumerable<BaseState> states);
    }
}