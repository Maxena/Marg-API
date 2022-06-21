using System.Configuration;
using Margs.Api.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

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
        .UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .WriteTo.PostgreSQL(cs,
                "Logs",
                needAutoCreateTable: true,
                schemaName: "marg-log").MinimumLevel
            .Information()
            .ReadFrom.Configuration(ctx.Configuration));

    // Add Service Extensions 
    builder.Services.Di(builder.Configuration);


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