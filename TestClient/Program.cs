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
            var worker = DependencyFactory.Instance.Resolve<IWorker>();
            var machine = worker.BuildStateMachine();
            worker.AddToContext(typeof(TestClientModel));
            worker.Execute(machine);

            System.Console.ReadLine();
        }
    }
}