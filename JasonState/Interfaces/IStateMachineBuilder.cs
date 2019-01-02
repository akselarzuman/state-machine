using System.Collections.Generic;
using JasonState.Models;
using System;

namespace JasonState.Interfaces
{
    public interface IStateMachineBuilder
    {
        StateMachineModel Load(string path);

        IEnumerable<BaseState> BuildMachine(StateMachineModel stateMachine);

        void AddToContext(Type type);

        void AddToContext(IEnumerable<Type> types);
    }
}