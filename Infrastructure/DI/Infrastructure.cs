using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class Infrastructure
{
    public static IServiceCollection InfrastructureDi(this IServiceCollection service, IConfiguration config)
    {
        service.AddTransient<IUnitOfWork>();
        service.AddDbContext<ApplicationDbContext>
        (option => option.UseSqlServer(config.GetConnectionString("Death"), _ =>
        {
            _.EnableRetryOnFailure(3);
            _.CommandTimeout(1400);
        }));

        return service;
    }
}