using System;
using JasonState.Models;

namespace TestClient.Impls.States
{
    public class ErrorState : BaseState
    {
        public override void Execute()
        {
            Console.WriteLine("An error happened...");
        }
    }
}