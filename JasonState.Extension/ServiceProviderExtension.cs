using JasonState.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JasonState
{
    public static class ServiceProviderExtension
    {
        public static void AddJasonState(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IStateMachine, StateMachine>();
        }

        public static void AddJasonState(this IServiceCollection serviceCollection, string assemblyName)
        {
            serviceCollection.AddTransient<IStateMachine>(m => new StateMachine(assemblyName));
        }
    }
}