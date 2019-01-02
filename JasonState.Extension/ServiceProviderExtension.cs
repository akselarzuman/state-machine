using JasonState.Impls;
using JasonState.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JasonState
{
    public static class ServiceProviderExtension
    {
        public static void AddJasonState(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IStateMachineBuilder, StateMachineBuilder>()
                .AddTransient<IStateMachineExecutor, StateMachineExecutor>();
        }
    }
}