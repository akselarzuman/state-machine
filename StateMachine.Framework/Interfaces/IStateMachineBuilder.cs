using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.Framework.Interfaces
{
    public interface IStateMachineBuilder
    {
        Models.StateMachine Load(string path);
        
        IEnumerable<BaseState> BuildMachine(Models.StateMachine stateMachine);
    }
}