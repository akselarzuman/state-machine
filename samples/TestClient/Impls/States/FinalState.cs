using JasonState.Models;
using TestClient.Models;

namespace TestClient.Impls.States
{
    public class FinalState : BaseState<TestClientModel>
    {
        public override void Execute(TestClientModel context)
        {
            System.Console.WriteLine("Final state executed.");
        }
    }
}