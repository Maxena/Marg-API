using System.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Margs.Api.Database;
using Margs.Api.Database.Context;
using Margs.Api.Services;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Modules;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile($"..\\SharedSettings\\sharedsettings.{environment}.JSON", true, true)
//     .AddJsonFile($"sharedsettings.{environment}.json", true, true)
//     .AddEnvironmentVariables()
//     .Build();

var cs = builder.Configuration.GetConnectionString("logging");

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration, "serilog")
    .WriteTo.PostgreSQL(cs,
        "Logs",
        needAutoCreateTable: true,
        schemaName: "marg-log").MinimumLevel
    .Information()
    .CreateLogger();

try
{
    Log.Information("Starting web host");

    builder.Host
        .UseServiceProviderFactory(
            new AutofacServiceProviderFactory())
        .UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .WriteTo.PostgreSQL(cs,
                "Logs",
                needAutoCreateTable: true,
                schemaName: "marg-log").MinimumLevel
            .Information()
            .ReadFrom.Configuration(ctx.Configuration))
        .ConfigureContainer<ContainerBuilder>(
            _ => _.RegisterModule(new ServicesModule(builder.Configuration))) // Add Register Module With Autofac
        .ConfigureServices(
            services => services.Di(builder.Configuration)); // Add Services To The Container


    var app = builder.Build();


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    if (args.Length == 1 && args[0].ToLower() == "seeddata")
        await SeedData(app);

    async Task SeedData(IHost apps)
    {
        var scopedFactory = apps.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory!.CreateScope();
        var service = scope.ServiceProvider.GetService<Seeder>();
        await service!.SeedRoles();
    }

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}