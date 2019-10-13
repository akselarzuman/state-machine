using System;
using System.Threading.Tasks;
using AsyncTestClient.Models;
using JasonState.Models;

namespace AsyncTestClient.Impls.States
{
    public class ExecutePaymentState : AsyncBaseState<TestClientModel>
    {
        public override async Task ExecuteAsync(TestClientModel context)
        {
            await Console.Out.WriteLineAsync("Error will be thrown from execute payment state...");
            throw new Exception();
        }
    }
}