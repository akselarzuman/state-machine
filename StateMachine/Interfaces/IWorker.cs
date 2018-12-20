using System.Collections.Generic;
using StateMachine.Models;
using StateMachine.Models.Base;

namespace StateMachine.TestClient.Interfaces
{
    public interface IWorker
    {
        StateMachineModel LoadStateMachine();
        
        IEnumerable<BaseState> BuildStateMachine(StateMachineModel stateMachine);
        
        void Execute(IEnumerable<BaseState> machine);
    }
}