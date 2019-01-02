﻿using JasonState.Models;

namespace TestClient.Impls.States
{
    public class ValidatePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Validate Payment state executed.");
        }
    }
}