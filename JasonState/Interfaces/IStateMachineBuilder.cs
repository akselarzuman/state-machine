using System.Collections.Generic;
using JasonState.Models;
using System;

namespace JasonState.Interfaces
{
    public interface IStateMachineBuilder
    {
        IEnumerable<BaseState> BuildMachine(string path);

        void AddToContext(Type type);

        void AddToContext(IEnumerable<Type> types);
    }
}