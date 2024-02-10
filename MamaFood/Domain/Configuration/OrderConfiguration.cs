using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaFood.API.Domain.Entities;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Configure primary key
        builder.HasKey(o => o.ID);

        // Configure properties
        builder.Property(o => o.DateTime)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(o => o.Duration)
            .IsRequired();

        builder.Property(o => o.TotalPrice)
            .IsRequired();

        builder.Property(o => o.UserId)
            .IsRequired();

        // Configure relationships

        builder.HasOne(o => o.SpecialRequest)
            .WithOne(sr => sr.Order)
            .HasForeignKey<Order>(o => o.ID);

        builder.HasOne(o => o.Review)
            .WithOne(r => r.Order)
            .HasForeignKey<Order>(o => o.ID);
    }
}
