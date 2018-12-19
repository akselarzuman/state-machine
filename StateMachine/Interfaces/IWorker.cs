using System.Collections.Generic;
using StateMachine.Models.Base;

namespace StateMachine.TestClient.Interfaces
{
    public interface IWorker
    {
        Models.StateMachine LoadStateMachine();
        
        IEnumerable<BaseState> BuildStateMachine(Models.StateMachine stateMachine);
        
        void Execute(IEnumerable<BaseState> machine);
    }
}