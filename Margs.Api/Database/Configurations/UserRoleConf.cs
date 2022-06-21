using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class UserRoleConf : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne(u => u.User)
            .WithMany(ur => ur.UserRoles)
            .HasForeignKey(u => u.UserId);

        builder.HasOne(r => r.Role)
            .WithMany(ur => ur.UserRoles)
            .HasForeignKey(r => r.RoleId);
    }
}