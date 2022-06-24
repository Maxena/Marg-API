using Margs.Api.Database.Context;
using Margs.Api.Services.Authentication;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Repos;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services;

public static class DependencyInjection
{
    private const string Jwt = "ApiSettings:JwtSetting";

    public static IServiceCollection Di(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<JwtSetting>(config.GetSection(Jwt));

        // services.AddSingleton<ILogger>(Log.Logger);
        // services.AddScoped<IAuthService, AuthService>();
        // services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        // services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}