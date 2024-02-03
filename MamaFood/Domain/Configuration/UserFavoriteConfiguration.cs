using MamaFood.API.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class UserFavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
{
    public void Configure(EntityTypeBuilder<UserFavorite> builder)
    {
        builder.HasKey(uf => uf.ID);
        builder.HasOne(uf => uf.User)
            .WithMany(u => u.UserFavorites)
            .HasForeignKey(uf => uf.UserID);
        // Configure other properties as needed
    }
}
