using TestClient.DI;
using TestClient.Interfaces;
using TestClient.Models;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyFactory.Instance.RegisterDependencies();

            var testModel = new TestClientModel();

            var worker = DependencyFactory.Instance.Resolve<IWorker<TestClientModel>>();
            var machine = worker.BuildStateMachine();
            worker.AddToContext(typeof(TestClientModel));
            worker.Execute(machine, testModel);

            System.Console.ReadLine();
        }
    }
}