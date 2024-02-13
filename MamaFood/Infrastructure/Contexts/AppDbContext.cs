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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }
        #endregion

        #region DbSet
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SpecialRequest> SpecialRequests { get; set; }
        public DbSet<UserLikeFood> UserLikeFoods { get; set; }
        public DbSet<UserLikeUser> UserLikeUsers { get; set; }

        #endregion
    }
}
