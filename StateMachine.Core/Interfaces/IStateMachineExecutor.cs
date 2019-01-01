using System.Collections.Generic;
using StateMachine.Core.Models;

namespace StateMachine.Core.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Execute(IEnumerable<BaseState> states);
    }
}