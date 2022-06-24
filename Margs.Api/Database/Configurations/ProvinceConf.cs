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
            .HasMaxLength(19)
            .HasColumnType("varchar(19)");

        builder.Property(_ => _.Slug)
            .HasMaxLength(17)
            .HasColumnType("varchar(17)");

        builder.Property(_ => _.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasMany(c => c.Cities)
            .WithOne(p => p.Province)
            .HasForeignKey(c => c.ProvinceId);
    }
}