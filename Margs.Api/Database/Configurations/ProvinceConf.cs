using Margs.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Margs.Api.Database.Configurations;

public class ProvinceConf : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id)
            .HasColumnName("ProvinceId");

        builder.Property(_ => _.Name)
            .HasMaxLength(15)
            .HasColumnType("varchar(15)");

        builder.HasMany(c => c.Cities)
            .WithOne(p => p.Province)
            .HasForeignKey(c => c.ProvinceId);
    }
}