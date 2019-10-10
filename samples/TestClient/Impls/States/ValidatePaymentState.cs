using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class ValidatePaymentState : BaseState<TestClientModel>
    {
        public override void Execute(TestClientModel context)
        {
            System.Console.WriteLine("Validate Payment state executed.");
        }
    }
}