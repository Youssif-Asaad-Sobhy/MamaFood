using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class UserFood
    {
        public int ID { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }
        [Required ,ForeignKey("User")]
        public required string UserID { get; set; }
        [Required]
        public double Price {  get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public required Food Food { get; set; }
        public required ApplicationUser User { get; set; }
        public ICollection<OrderUserFood> OrderUserFoods { get; set; }
    }
}
