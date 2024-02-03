using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class UserFavorite
    {
        public int ID { get; set; }
        [Required ,ForeignKey("User")]
        public required string UserID { get; set; }
        public required ApplicationUser User { get; set; }
        ICollection<ApplicationUser>? Users { get; set; }
        ICollection<UserFood>? UserFoods { get; set; }
    }
}
