using AuthService.Infrastructure.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace AuthService.Infrastructure
{
    public static class DependenciInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("redis")!));
            return services;
        }
    }
}
