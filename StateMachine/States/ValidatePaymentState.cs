﻿using StateMachine.Models.Base;

namespace StateMachine.Fremework.States
{
    public class ValidatePaymentState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Validate Payment state executed.");
        }
    }
}