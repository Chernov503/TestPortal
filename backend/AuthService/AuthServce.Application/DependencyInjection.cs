using AuthServce.Application.Interfaces;
using AuthServce.Application.JWT;
using AuthServce.Application.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace AuthServce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(x => x.AddMaps(typeof(AuthMapperProfile)));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey
                                (Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!)) //TODO: переменная окружения
                    };
                });
            services.AddAuthorization();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


            return services;
        }

    }
}
