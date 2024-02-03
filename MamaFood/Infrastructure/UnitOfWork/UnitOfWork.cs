using MamaFood.API.Domain.Entities;
using MamaFood.API.Infrastructure.Contexts;
using MamaFood.API.Infrastructure.Generics;

namespace MamaFood.API.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<ApplicationUser> Users { get; private set; }
        public IBaseRepository<Category> Categories { get; private set;}
        public IBaseRepository<Food> Foods { get; private set;}
        public IBaseRepository<Order> Orders { get; private set;}
        public IBaseRepository<OrderUserFood> OrderUserFoods { get; private set;}
        public IBaseRepository<Review> Reviews { get; private set;}
        public IBaseRepository<UserFavorite> UserFavorites { get; private set;}
        public IBaseRepository<UserFood> UserFoods { get; private set;}
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users=new BaseRepository<ApplicationUser>(context);
            Categories=new BaseRepository<Category>(context);
            Foods = new BaseRepository<Food>(context);
            Orders=new BaseRepository<Order>(context);
            OrderUserFoods = new BaseRepository<OrderUserFood>(context);
            Reviews = new BaseRepository<Review>(context);
            UserFavorites = new BaseRepository<UserFavorite>(context);
            UserFoods = new BaseRepository<UserFood>(context); 
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
