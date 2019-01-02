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
            var stateMachine = worker.LoadStateMachine();
            var machine = worker.BuildStateMachine(stateMachine);
            worker.AddToContext(typeof(TestClientModel));
            worker.Execute(machine);

            System.Console.ReadLine();
        }
    }
}