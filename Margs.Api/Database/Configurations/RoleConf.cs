using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class RoleConf : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id)
            .HasColumnName("RoleId")
            .ValueGeneratedOnAdd();

        builder.Property(_ => _.Name)
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(_ => _.Description)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(_ => _.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder.HasMany(ur => ur.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(ur => ur.RoleId);
    }
}