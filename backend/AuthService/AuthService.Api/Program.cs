using AuthService.Api;
using AuthService.Infrastructure;
using AuthServce.Application;
using AuthService.Infrastructure.PostgreSQL;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddApiServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration)
            .AddApplicationServices(builder.Configuration);


        var app = builder.Build();

        MigrateDb(app);

        app.UseApiServices();

        app.Run();
    }
    static void MigrateDb(IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
        dbContext.Database.Migrate();
    }
}