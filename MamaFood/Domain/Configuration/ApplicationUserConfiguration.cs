using MamaFood.API.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasOne(u => u.UserFavorites)
                .WithOne(uf => uf.User)
                .HasForeignKey<UserFavorite>(uf => uf.UserID);
        // Configure other properties as needed
    }
}
