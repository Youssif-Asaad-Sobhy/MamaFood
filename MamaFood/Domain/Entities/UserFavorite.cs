namespace MamaFood.API.Domain.Entities
{
    public class UserFavorite
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        ICollection<User> BaseUsers { get; set; }
        ICollection<UserFood> UserFoods { get; set; }
    }
}
