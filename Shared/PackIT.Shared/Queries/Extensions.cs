using Microsoft.Extensions.DependencyInjection;
using PackIT.SharedAbstractions.Queries;
using System.Reflection;

namespace PackIT.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            // Scrutor: an assembly scanning for Automatic Registration.
            var assembly = Assembly.GetCallingAssembly();
            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}