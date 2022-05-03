using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Commands;
using PackIT.SharedAbstractions.Commands;
using System.Reflection;

namespace PackIT.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            // Scrutor: an assembly scanning for Automatic Registration.
            var assembly = Assembly.GetCallingAssembly();
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}