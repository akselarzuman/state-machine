using JasonState.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JasonState
{
    public static class ServiceProviderExtension
    {
        public static void AddJasonState<T>(this IServiceCollection serviceCollection) where T : class, new()
        {
            serviceCollection
                .AddTransient<IAssemblyProvider, AssemblyProvider>()
                .AddTransient<IStateMachine<T>, StateMachine<T>>();
        }

        public static void AddJasonState<T>(this IServiceCollection serviceCollection, string assemblyName) where T : class, new()
        {
            serviceCollection.AddTransient<IStateMachine<T>>(m => new StateMachine<T>(assemblyName));
        }
    }
}