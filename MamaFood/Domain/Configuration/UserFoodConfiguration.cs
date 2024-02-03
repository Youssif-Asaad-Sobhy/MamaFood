using MamaFood.API.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class UserFoodConfiguration : IEntityTypeConfiguration<UserFood>
{
    public void Configure(EntityTypeBuilder<UserFood> builder)
    {
        builder.HasKey(uf => uf.ID);
        builder.HasOne(uf => uf.User)
            .WithMany(u => u.UserFoods)
            .HasForeignKey(uf => uf.UserID);
        builder.HasOne(uf => uf.Food)
            .WithMany(f => f.UserFoods)
            .HasForeignKey(uf => uf.FoodID);
        // Configure other properties as needed
    }
}
