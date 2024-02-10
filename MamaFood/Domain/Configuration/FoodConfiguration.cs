using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaFood.API.Domain.Entities;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        // Configure primary key
        builder.HasKey(f => f.ID);

        // Configure properties
        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(20);

        // Configure relationships
        builder.HasOne(f => f.Menu)
            .WithMany(m => m.Foods)
            .HasForeignKey(f => f.MenuID);
        
        builder.HasMany(f => f.Orders)
            .WithMany(o => o.Foods)
            .UsingEntity<FoodOrder>();
    }
}
