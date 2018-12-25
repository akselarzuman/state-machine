using Microsoft.Extensions.DependencyInjection;
using StateMachine.Core.Impls;
using StateMachine.Core.Interfaces;
using StateMachine.TestClient.Impls;
using StateMachine.TestClient.Interfaces;

namespace StateMachine.TestClient.DI
{
    public class DependencyFactory
    {
        public static readonly DependencyFactory Instance = new DependencyFactory();

        private ServiceProvider _serviceProvider;

        protected DependencyFactory()
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
            serviceCollection
                .AddTransient<IStateMachineBuilder, StateMachineBuilder>()
                .AddTransient<IStateMachineExecutor, StateMachineExecutor>()
                .AddTransient<IWorker, Worker>();
        }
    }
}