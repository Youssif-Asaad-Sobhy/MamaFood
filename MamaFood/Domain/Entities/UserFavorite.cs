using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class UserFavorite
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }
        ICollection<User>? Users { get; set; }
        ICollection<UserFood>? UserFoods { get; set; }
    }
}
