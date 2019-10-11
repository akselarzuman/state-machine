using System.Threading.Tasks;
using AsyncTestClient.Models;
using JasonState.Models;

namespace AsyncTestClient.Impls.States
{
    public class FinalState : AsyncBaseState<TestClientModel>
    {
        public override async Task ExecuteAsync(TestClientModel context)
        {
            await System.Console.Out.WriteLineAsync("Final state executed.");
        }
    }
}