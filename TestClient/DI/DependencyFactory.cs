﻿using JasonState;
using Microsoft.Extensions.DependencyInjection;
using TestClient.Impls;
using TestClient.Interfaces;

namespace TestClient.DI
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
            serviceCollection.AddJasonState();
            serviceCollection.AddTransient<IWorker, Worker>();
        }
    }
}