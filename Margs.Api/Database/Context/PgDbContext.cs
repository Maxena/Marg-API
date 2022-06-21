using Margs.Api.Common;
using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Margs.Api.Database.Context;

public class PgDbContext : DbContext
{
    public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var assembly = typeof(IEntity).Assembly;

        modelBuilder.RegisterAllEntities<IEntity>(assembly);
        modelBuilder.RegisterEntityTypeConfiguration(assembly);
        modelBuilder.AddPluralizingTableNameConvention();
    }
}