using System.Collections.Generic;
using StateMachine.Models.Base;
using StateMachine.Models;

namespace StateMachine.Framework.Interfaces
{
    public interface IStateMachineBuilder
    {
        StateMachineModel Load(string path);

        IList<BaseState> BuildMachine(StateMachineModel stateMachine);
    }
}