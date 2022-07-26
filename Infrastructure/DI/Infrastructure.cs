using System.Globalization;
using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.MSSqlServer;

namespace Infrastructure.DI;

public static class Infrastructure
{
    private static ILogger? _seriLog;

    public static IServiceCollection InfrastructureDi(this IServiceCollection service, IConfiguration config)
    {
        #region Variables

        var dateTimeNow = DateTime.Now;
        var dayOfWeek = new PersianCalendar().GetDayOfWeek(dateTimeNow);

        #endregion


        _seriLog = new LoggerConfiguration()
            .WriteTo.File($"Logs/{dayOfWeek}|{dateTimeNow}.log", rollingInterval: RollingInterval.Hour)
            .WriteTo.MSSqlServer(config.GetConnectionString("SeriLog"), sinkOptions: new MSSqlServerSinkOptions
            {
                AutoCreateSqlTable = true,
                TableName = "Logging",
                SchemaName = "SeriLog"
            }, columnOptions: new ColumnOptions
            {
                Exception = new ColumnOptions.ExceptionColumnOptions
                {
                    AllowNull = true,
                    ColumnName = "Exception",
                    NonClusteredIndex = false,
                    PropertyName = "Exception"
                }
            })
            .WriteTo.Console()
            .WriteTo.Seq("https://116.203.234.94:8443")
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .CreateLogger();

        service.AddTransient<IUnitOfWork>();
        service.AddDbContext<ApplicationDbContext>
        (option => option.UseSqlServer(config.GetConnectionString("Death"), _ =>
        {
            _.EnableRetryOnFailure(3);
            _.CommandTimeout(1400);
        }));

        service.AddLogging(_ => _.AddSerilog(_seriLog));

        return service;
    }
}