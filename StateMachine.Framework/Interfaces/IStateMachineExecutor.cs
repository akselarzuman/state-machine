using StateMachine.Fremework.Interfaces;

namespace StateMachine.Fremework.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Run(Entities.StateMachine stateMachine);
    }
}