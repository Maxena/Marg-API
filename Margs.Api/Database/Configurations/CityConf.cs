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
            .HasMaxLength(10)
            .HasColumnType("varchar(10)");

        builder.HasOne(p => p.Province)
            .WithMany(c => c.Cities)
            .HasForeignKey(p => p.ProvinceId);

        builder.HasMany(u => u.Users)
            .WithOne(c => c.City)
            .HasForeignKey(u => u.CityId);
    }
}