﻿using StateMachine.Entities.Base;

namespace StateMachine.Fremework.States
{
    public class FinalState : BaseState
    {
        public override void Execute()
        {
            System.Console.WriteLine("Final state executed.");
        }
    }
}