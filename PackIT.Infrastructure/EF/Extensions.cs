using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Options;
using PackIT.Shared.Options;

namespace PackIT.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlServerOptions>("SqlServer");
            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            return services;
        }
    }
}