using Autofac;
using AutofacSerilogIntegration;
using Margs.Api.Database;
using Margs.Api.Database.Context;
using Margs.Api.Services.Authentication;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Repos;
using Microsoft.EntityFrameworkCore;
using Serilog.Core;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Modules;

public class ServicesModule : Module
{
    public ServicesModule(IConfiguration config)
    {
        Config = config;
    }

    public IConfiguration Config { get; set; }

    protected override void Load(ContainerBuilder builder)
    {
        //Transient
        // builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency();


        //Singleton
        // builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();

        //Scoped
        // builder.RegisterType<AuthService>().As<IAuthService>().InstanceLifetimeScope();

        builder.Register(_ =>
        {
            var optionBuilder = new DbContextOptionsBuilder<PgDbContext>();
            optionBuilder.UseNpgsql(Config.GetConnectionString("PgSql"));
            return new PgDbContext(optionBuilder.Options);
        }).InstancePerLifetimeScope();

        builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
        builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>().SingleInstance();
        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().SingleInstance();
        builder.RegisterLogger(); // for serilog to use it with autofac and we should use this package ==> AutofacSerilogIntegration
        builder.RegisterType<Seeder>().InstancePerDependency();
        base.Load(builder);
    }
}