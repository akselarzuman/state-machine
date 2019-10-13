using System.Threading.Tasks;
using AsyncTestClient.Models;
using JasonState.Models;

namespace AsyncTestClient.Impls.States
{
    public class ValidatePaymentState : AsyncBaseState<TestClientModel>
    {
        public override async Task ExecuteAsync(TestClientModel context)
        {
            await System.Console.Out.WriteLineAsync("Validate Payment state executed.");
        }
    }
}