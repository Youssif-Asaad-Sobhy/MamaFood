using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class UserFood
    {
        public int ID { get; set; }
        public double Price {  get; set; }
        public string Description { get; set; }
        public int FoodID { get; set; }
        public string UserID { get; set; }
        public Food Food { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderUserFood> OrderUserFoods { get; set; }
    }
}
