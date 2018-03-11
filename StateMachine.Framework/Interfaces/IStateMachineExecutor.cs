using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.Framework.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Execute(IList<BaseState> machine);
    }
}