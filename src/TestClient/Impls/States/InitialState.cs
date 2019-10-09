using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class InitialState : BaseState<TestClientModel>
    {
        public override void Execute(TestClientModel context)
        {
            // this is an example of how you can use this framework

            context.FromEmail = "aksel@test.com";
            context.ToEmail = "xena@warrior.com";
            context.CreditCardNumber = 7848995422321010;
            context.CardHolderName = "Aksel Test";
            context.Amount = 50;

            System.Console.WriteLine("Initial state executed.");
        }
    }
}