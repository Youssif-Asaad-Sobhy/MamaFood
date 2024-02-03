using MamaFood.API.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MamaFood.API.Infrastructure.Contexts
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        #region Constructors
        //public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        #endregion

        #region methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().
                HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            new ApplicationUserConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new FoodConfiguration().Configure(modelBuilder.Entity<Food>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new OrderUserFoodConfiguration().Configure(modelBuilder.Entity<OrderUserFood>());
            new ReviewConfiguration().Configure(modelBuilder.Entity<Review>());
            new UserFavoriteConfiguration().Configure(modelBuilder.Entity<UserFavorite>());
            new UserFoodConfiguration().Configure(modelBuilder.Entity<UserFood>());
            base.OnModelCreating(modelBuilder);

        }
        #endregion

        #region DbSet
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Food>Foods { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderUserFood>OrderUserFoods { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        #endregion
    }
}
