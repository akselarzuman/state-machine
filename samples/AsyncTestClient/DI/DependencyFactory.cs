using AsyncTestClient.Impls;
using AsyncTestClient.Interfaces;
using AsyncTestClient.Models;
using JasonState;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncTestClient.DI
{
    public class DependencyFactory
    {
        public static readonly DependencyFactory Instance = new DependencyFactory();

        private ServiceProvider _serviceProvider;

        private DependencyFactory()
        {
        }

        public void RegisterDependencies()
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddAsyncJasonState<TestClientModel>();
            serviceCollection.AddTransient<IWorker<TestClientModel>, Worker<TestClientModel>>();
        }
    }
}