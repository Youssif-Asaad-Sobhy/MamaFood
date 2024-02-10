using MamaFood.API.Domain.Entities;
using MamaFood.API.Infrastructure.Generics;

namespace MamaFood.API.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ApplicationUser> Users { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Food> Foods { get; }
        IBaseRepository<FoodCategory> FoodCategories { get; }
        IBaseRepository<FoodOrder> FoodOrders { get; }
        IBaseRepository<Menu> Menus { get; }
        IBaseRepository<Offer> Offers { get; }
        IBaseRepository<Order> Orders { get; }
        IBaseRepository<Report> Reports { get; }
        IBaseRepository<Review> Reviews { get; }
        IBaseRepository<SpecialRequest> SpecialRequests { get; }
        IBaseRepository<UserLikeFood> UserLikeFoods { get; }
        IBaseRepository<UserLikeUser> UserLikeUsers { get; }
        int Complete();
    }
}
