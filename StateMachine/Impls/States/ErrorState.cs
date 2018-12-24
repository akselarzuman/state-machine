using System;
using StateMachine.Core.Models;

namespace StateMachine.TestClient.Impls.States
{
    public class ErrorState : BaseState
    {
        public override void Execute()
        {
            Console.WriteLine("An error happened...");
        }
    }
}