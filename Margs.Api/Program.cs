using System.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Margs.Api.Database;
using Margs.Api.Database.Context;
using Margs.Api.Services;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Modules;
using Microsoft.AspNetCore.HttpOverrides;
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


    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marg API V1");
        c.DocumentTitle = "Marg API";
        c.DisplayRequestDuration();
        c.EnableTryItOutByDefault();
        //c.DocExpansion(DocExpansion.None);

        //c.RoutePrefix = string.Empty;
    });

    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();
    else
    {
        app.UseDeveloperExceptionPage();
        app.UseHsts();
    }

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });


    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseResponseCaching();

    app.UseResponseCompression();

    app.UseRouting();

    app.UseCors(x => x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(s => true)
        .AllowCredentials());

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