using StateMachine.Fremework.Base;

namespace StateMachine.Fremework.Interfaces
{
    public interface IStateMachineExecutor
    {
        void Run(Entities.StateMachine stateMachine);
    }
}