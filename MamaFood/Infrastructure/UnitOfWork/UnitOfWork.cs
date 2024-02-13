using MamaFood.API.Domain.Entities;
using MamaFood.API.Infrastructure.Contexts;
using MamaFood.API.Infrastructure.Generics;

namespace MamaFood.API.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<ApplicationUser> Users { get; private set; }
        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Food> Foods { get; private set; }
        public IBaseRepository<FoodCategory> FoodCategories { get; private set; }
        public IBaseRepository<FoodOrder> FoodOrders { get; private set; }
        public IBaseRepository<Menu> Menus { get; private set; }
        public IBaseRepository<Offer> Offers { get; private set; }
        public IBaseRepository<Order> Orders { get; private set; }
        public IBaseRepository<Report> Reports { get; private set; }
        public IBaseRepository<Review> Reviews { get; private set; }
        public IBaseRepository<SpecialRequest> SpecialRequests { get; private set; }
        public IBaseRepository<UserLikeFood> UserLikeFoods { get; private set; }
        public IBaseRepository<UserLikeUser> UserLikeUsers { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new BaseRepository<ApplicationUser>(context);
            Categories = new BaseRepository<Category>(context);
            Foods = new BaseRepository<Food>(context);
            FoodCategories = new BaseRepository<FoodCategory>(context);
            FoodOrders = new BaseRepository<FoodOrder>(context);
            Menus = new BaseRepository<Menu>(context);
            Offers = new BaseRepository<Offer>(context);
            Orders = new BaseRepository<Order>(context);
            Reports = new BaseRepository<Report>(context);
            Reviews = new BaseRepository<Review>(context);
            SpecialRequests = new BaseRepository<SpecialRequest>(context);
            UserLikeFoods = new BaseRepository<UserLikeFood>(context);
            UserLikeUsers = new BaseRepository<UserLikeUser>(context);
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
