using System.Threading.Tasks;
using AsyncTestClient.Models;
using JasonState.Models;

namespace AsyncTestClient.Impls.States
{
    public class InitialState : AsyncBaseState<TestClientModel>
    {
        public override async Task ExecuteAsync(TestClientModel context)
        {
            // this is an example of how you can use this framework

            context.FromEmail = "aksel@test.com";
            context.ToEmail = "xena@warrior.com";
            context.CreditCardNumber = 7848995422321010;
            context.CardHolderName = "Aksel Test";
            context.Amount = 50;

            await System.Console.Out.WriteLineAsync("Initial state executed.");
        }
    }
}