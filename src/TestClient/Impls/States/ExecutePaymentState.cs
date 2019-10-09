using System;
using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class ExecutePaymentState : BaseState<TestClientModel>
    {
        public override void Execute(TestClientModel context)
        {
            Console.WriteLine("Error will be thrown from execute payment state...");
            throw new System.Exception();
        }
    }
}