using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.Fremework.Interfaces
{
    public interface IStateMachineBuilder
    {
        Models.StateMachine Load(string path);
        IList<BaseState> BuildMachine(Models.StateMachine stateMachine);
    }
}