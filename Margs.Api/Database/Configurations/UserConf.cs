using Margs.Api.Common;
using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class UserConf : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .HasColumnName("UserId")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Mobile)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(p => p.Gender)
            .IsRequired();

        builder.Property(_ => _.FirstName)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(_ => _.LastName)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(_ => _.Email)
            .HasMaxLength(40)
            .HasColumnType("varchar(40)");

        builder.Property(_ => _.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasOne(c => c.City)
            .WithMany(u => u.Users)
            .HasForeignKey(c => c.CityId);

        builder.HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId);

        builder.HasMany(a => a.Addresses)
            .WithOne(u => u.User)
            .HasForeignKey(a => a.UserId);

        builder.Property(_ => _.IsActive)
            .HasDefaultValue(false);
    }
}