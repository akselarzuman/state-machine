using System;
using JasonState.Models;

namespace TestClient.Impls.States
{
    public class ExecutePaymentState : BaseState
    {
        public override void Execute()
        {
            Console.WriteLine("Error will be thrown from execute payment state...");
            throw new System.Exception();
        }
    }
}