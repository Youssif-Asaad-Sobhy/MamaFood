using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        public string UserID { get; set; }
        public Review Review { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderUserFood> OrderUserFoods { get; set; }
    }
}
