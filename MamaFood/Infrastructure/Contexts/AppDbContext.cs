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

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(r => r.Reviews)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.Creator)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(o => o.Orders)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Cascade);
            // Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Foods)
                .WithOne(f => f.Category)
                .HasForeignKey(f => f.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Food
            modelBuilder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Order
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderUserFoods)
                .WithOne(o => o.Order)
                .HasForeignKey(of => of.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(r => r.Review)
                .WithOne(o => o.Order)
                .HasForeignKey<Review>(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // UserFood
            modelBuilder.Entity<UserFood>()
                .HasMany(uf => uf.OrderUserFoods)
                .WithOne(of => of.UserFood)
                .HasForeignKey(of => of.UserFoodID)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderUserFood
            modelBuilder.Entity<OrderUserFood>()
                .HasOne(of => of.Order)
                .WithMany(o => o.OrderUserFoods)
                .HasForeignKey(of => of.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderUserFood>()
                .HasOne(of => of.UserFood)
                .WithMany(uf => uf.OrderUserFoods)
                .HasForeignKey(of => of.UserFoodID)
                .OnDelete(DeleteBehavior.Restrict);

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
