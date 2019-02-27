using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class InitialState : BaseState
    {
        public override void Execute()
        {
            // this is an example of how you can use this framework

            TestClientModel.FromEmail = "aksel@test.com";
            TestClientModel.ToEmail = "xena@warrior.com";
            TestClientModel.CreditCardNumber = 7848995422321010;
            TestClientModel.CardHolderName = "Aksel Test";
            TestClientModel.Amount = 50;

            System.Console.WriteLine("Initial state executed.");
        }
    }
}