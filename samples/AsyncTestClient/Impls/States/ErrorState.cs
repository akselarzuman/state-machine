using System;
using System.Threading.Tasks;
using AsyncTestClient.Models;
using JasonState.Models;

namespace AsyncTestClient.Impls.States
{
    public class ErrorState : AsyncBaseState<TestClientModel>
    {
        public override async Task ExecuteAsync(TestClientModel context)
        {
            await Console.Out.WriteLineAsync("An error happened...");
        }
    }
}