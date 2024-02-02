using MamaFood.API.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MamaFood.API.Infrastructure.Contexts
{
    public class Context:IdentityDbContext<User>
    {
        #region Constructors
        public Context(){}
        public Context(DbContextOptions<Context> options) : base(options){}
        #endregion

        #region methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .WithOne(of => of.Order)
                .HasForeignKey(of => of.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

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

            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Order)
                .WithOne(o => o.Review)
                .HasForeignKey<Review>(r => r.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region DbSet
        public DbSet<Category>Categories { get; set; }
        public DbSet<Food>Foods { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderUserFood>OrderFoods { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        #endregion
    }
}
