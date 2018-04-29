using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.TestClient.Interfaces
{
    public interface IWorker
    {
        Models.StateMachineModel LoadStateMachine();
        IList<BaseState> BuildStateMachine(Models.StateMachineModel stateMachine);
        void Execute(IList<BaseState> machine);
    }
}