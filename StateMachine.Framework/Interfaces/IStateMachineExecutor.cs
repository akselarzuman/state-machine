using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.Fremework.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Execute(IList<BaseState> machine);
    }
}