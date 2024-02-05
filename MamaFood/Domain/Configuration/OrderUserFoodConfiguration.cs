using MamaFood.API.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class OrderUserFoodConfiguration : IEntityTypeConfiguration<OrderUserFood>
{
    public void Configure(EntityTypeBuilder<OrderUserFood> builder)
    {
        builder.HasKey(o => o.ID);
        builder.HasOne(o => o.Order)
            .WithMany(o => o.OrderUserFoods)
            .HasForeignKey(o => o.OrderID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.UserFood)
            .WithMany(uf => uf.OrderUserFoods)
            .HasForeignKey(o => o.UserFoodID)
            .OnDelete(DeleteBehavior.Restrict);
        // Configure other properties as needed
    }
}
