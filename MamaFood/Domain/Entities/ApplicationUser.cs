using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(14)]
        public string NID { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public int UserFavoritesID { get; set; }
        public UserFavorite UserFavorites { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserFood> UserFoods { get; set; }
    }
}
