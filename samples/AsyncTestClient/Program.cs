using System.Threading.Tasks;
using AsyncTestClient.DI;
using AsyncTestClient.Interfaces;
using AsyncTestClient.Models;

namespace AsyncTestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DependencyFactory.Instance.RegisterDependencies();

            var testModel = new TestClientModel();

            var worker = DependencyFactory.Instance.Resolve<IWorker<TestClientModel>>();
            var machine = await worker.BuildStateMachineAsync();
            await worker.ExecuteAsync(machine, testModel);
        }
    }
}