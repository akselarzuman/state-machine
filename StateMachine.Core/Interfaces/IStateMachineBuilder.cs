using System.Collections.Generic;
using StateMachine.Core.Models;
using System;

namespace StateMachine.Core.Interfaces
{
    public interface IStateMachineBuilder
    {
        StateMachineModel Load(string path);

        IEnumerable<BaseState> BuildMachine(StateMachineModel stateMachine);

        void AddToContext(Type type);

        void AddToContext(IEnumerable<Type> types);
    }
}