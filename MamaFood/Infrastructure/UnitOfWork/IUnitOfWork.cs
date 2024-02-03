using MamaFood.API.Domain.Entities;
using MamaFood.API.Infrastructure.Generics;

namespace MamaFood.API.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ApplicationUser> Users {  get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Food> Foods { get; }
        IBaseRepository<Order> Orders { get; }
        IBaseRepository<OrderUserFood> OrderUserFoods { get; }
        IBaseRepository<Review> Reviews { get; }
        IBaseRepository<UserFavorite> UserFavorites { get; }
        IBaseRepository<UserFood> UserFoods { get; }
        int Complete();
    }
}
