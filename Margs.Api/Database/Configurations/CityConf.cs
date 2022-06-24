using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class CityConf : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id)
            .HasColumnName("CityId");

        builder.Property(_ => _.Name)
            .HasMaxLength(17)
            .HasColumnType("varchar(17)");

        builder.Property(_ => _.Slug)
            .HasMaxLength(26)
            .HasColumnType("varchar(26)");

        builder.Property(_ => _.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasOne(p => p.Province)
            .WithMany(c => c.Cities)
            .HasForeignKey(p => p.ProvinceId);

        builder.HasMany(u => u.Users)
            .WithOne(c => c.City)
            .HasForeignKey(u => u.CityId);
    }
}