using System.Collections.Generic;
using StateMachine.Core.Models;

namespace StateMachine.TestClient.Interfaces
{
    public interface IWorker
    {
        StateMachineModel LoadStateMachine();
        
        IEnumerable<BaseState> BuildStateMachine(StateMachineModel stateMachine);
        
        void Execute(IEnumerable<BaseState> machine);
    }
}