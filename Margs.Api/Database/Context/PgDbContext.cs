using Margs.Api.Common;
using Margs.Api.Database.Configurations;
using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Margs.Api.Database.Context;

public class PgDbContext : DbContext
{
    public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Province> Provinces { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<Role> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConf());

        modelBuilder.ApplyConfiguration(new RoleConf());

        modelBuilder.ApplyConfiguration(new UserRoleConf());

        modelBuilder.ApplyConfiguration(new AddressConf());

        modelBuilder.ApplyConfiguration(new CityConf());

        modelBuilder.ApplyConfiguration(new ProvinceConf());
    }
}