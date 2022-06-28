using Autofac;
using AutofacSerilogIntegration;
using Margs.Api.Database;
using Margs.Api.Database.Context;
using Margs.Api.Services.Authentication;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Interfaces.County;
using Margs.Api.Services.Interfaces.User_Role;
using Margs.Api.Services.Repos;
using Margs.Api.Services.Repos.County;
using Margs.Api.Services.Repos.User_Role;
using Margs.Api.Services.UOW;
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
            optionBuilder.UseNpgsql(Config.GetConnectionString("PgSql"), options =>
            {
                options.EnableRetryOnFailure(5);
                options.CommandTimeout(300);
            });
            return new PgDbContext(optionBuilder.Options);
        }).InstancePerLifetimeScope();

        builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
        builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>().SingleInstance();
        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().SingleInstance();
        builder.RegisterLogger(); // for serilog to use it with autofac and we should use this package ==> AutofacSerilogIntegration
        builder.RegisterType<Seeder>().InstancePerDependency();
        builder.RegisterType<CoreServices>().As<ICoreServices>().SingleInstance();
        
        
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
        builder.RegisterType<UserService>().As<UserService>().InstancePerLifetimeScope();
        builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
        builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
        builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();
        builder.RegisterType<ProvincService>().As<IProvinceService>().InstancePerLifetimeScope();


        base.Load(builder);
    }
}