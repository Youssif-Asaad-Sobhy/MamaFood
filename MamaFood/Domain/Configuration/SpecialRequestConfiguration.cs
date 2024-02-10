using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaFood.API.Domain.Entities;

public class SpecialRequestConfiguration : IEntityTypeConfiguration<SpecialRequest>
{
    public void Configure(EntityTypeBuilder<SpecialRequest> builder)
    {
        // Configure primary key
        builder.HasKey(sr => sr.Id);

        // Configure properties
        builder.Property(sr => sr.Name)
            .IsRequired();

        builder.Property(sr => sr.Description)
            .IsRequired();

        builder.Property(sr => sr.MinPrice)
            .IsRequired();

        builder.Property(sr => sr.MaxPrice)
            .IsRequired();

        builder.Property(sr => sr.UserId)
            .IsRequired();

        // Configure relationships
        builder.HasOne(sr => sr.Order)
            .WithOne(o => o.SpecialRequest)
            .HasForeignKey<SpecialRequest>(sr => sr.Id);
    }
}
