using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaFood.API.Domain.Entities;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // Configure primary key
        builder.HasKey(u => u.Id);

        // Configure properties
        builder.Property(u => u.NID)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(u => u.Description)
            .HasMaxLength(200);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(20);

        // Configure relationships
        builder.HasMany(u => u.Users)
            .WithMany(u => u.Resturants)
            .UsingEntity<UserLikeUser>();

        builder.HasMany(u => u.Foods)
            .WithMany(f => f.Users)
            .UsingEntity<UserLikeFood>();

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);

        builder.HasMany(u => u.Offers)
            .WithOne(of => of.User)
            .HasForeignKey(of => of.UserId);

        builder.HasMany(u => u.Reports)
            .WithOne(r => r.AccusedUser)
            .HasForeignKey(r => r.AccusedId);
          
        builder.HasMany(u => u.Reports)
            .WithOne(r => r.CreatorUser)
            .HasForeignKey(r => r.CreatorId);

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);

        builder.HasMany(u => u.SpecialRequests)
            .WithOne(sr => sr.User)
            .HasForeignKey(sr => sr.UserId);
    }
}
