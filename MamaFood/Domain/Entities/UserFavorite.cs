using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class UserFavorite
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<UserFood> UserFoods { get; set; }
    }
}
