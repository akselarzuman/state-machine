using System;
using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class ErrorState : BaseState<TestClientModel>
    {
        public override void Execute(TestClientModel context)
        {
            Console.WriteLine("An error happened...");
        }
    }
}