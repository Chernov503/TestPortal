using AuthServce.Application.Interfaces;
using AuthServce.Application.JWT;
using AuthService.Infrastructure.Clients;
using AuthService.Infrastructure.PostgreSQL;
using AuthService.Infrastructure.PostgreSQL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace AuthService.Infrastructure
{
    public static class DependenciInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UserServiceSettings>(configuration.GetSection("UserServiceSettings"));

            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
            });

            services.AddHttpClient<IUserServiceClient, UserServiceClient>((sp, client) =>
            {
                var userServiceSettings = sp.GetRequiredService<IOptions<UserServiceSettings>>().Value;
                client.BaseAddress = userServiceSettings.BaseUri;
            });

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("redis")!));
            services.AddScoped<IBanRecordRepository, BanRecordRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IUserServiceClient, UserServiceClient>();
            

            return services;
        }
    }
}
