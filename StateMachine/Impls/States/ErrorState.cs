using System;
using StateMachine.Models.Base;

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