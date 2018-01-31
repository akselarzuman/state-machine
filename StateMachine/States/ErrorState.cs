using System;
using StateMachine.Models.Base;

namespace StateMachine.Fremework.States
{
    public class ErrorState : BaseState
    {
        public override void Execute()
        {
            Console.WriteLine("An error happened...");
        }
    }
}