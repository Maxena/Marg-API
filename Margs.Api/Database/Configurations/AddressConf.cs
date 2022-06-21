using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class AddressConf : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Main)
            .HasMaxLength(60)
            .HasColumnType("varchar(60)");

        builder.Property(_ => _.Detail)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder.HasOne(u => u.User)
            .WithMany(a => a.Addresses)
            .HasForeignKey(u => u.UserId);
    }
}