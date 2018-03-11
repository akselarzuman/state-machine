using StateMachine.TestClient.DI;
using StateMachine.TestClient.Interfaces;

namespace StateMachine.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyFactory.Instance.RegisterDependencies();

            IWorker worker = DependencyFactory.Instance.Resolve<IWorker>();

            var stateMachine = worker.LoadStateMachine();

            var machine = worker.BuildStateMachine(stateMachine);

            worker.Execute(machine);
        }
    }
}