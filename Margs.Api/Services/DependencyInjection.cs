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
        services.AddDbContext<PgDbContext>(_ =>
            _.UseNpgsql("Host=localhost;Port=5432;Database=marg;Username=maxena;Password=CabinPwd;"));

        services.AddSingleton<ILogger>(Log.Logger);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IAuthService, AuthService>();
        services.Configure<JwtSetting>(config.GetSection(Jwt));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}