using System;
using System.Collections.Generic;
using JasonState.Models;

namespace JasonState.Interfaces
{
    public interface IStateMachine
    {
        IEnumerable<BaseState> BuildMachine(string path);

        void AddToContext(Type type);

        void AddToContext(IEnumerable<Type> types);
        
        void Execute(IEnumerable<BaseState> states);
    }
}