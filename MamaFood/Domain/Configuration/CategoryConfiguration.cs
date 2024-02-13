using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaFood.API.Domain.Entities;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Configure primary key
        builder.HasKey(c => c.ID);

        // Configure properties
        builder.Property(c => c.title)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Description)
            .HasMaxLength(200);

        // Configure relationships
        builder.HasMany(c => c.foods)
            .WithMany(f => f.Categories)
            .UsingEntity<FoodCategory>();
    }
}
