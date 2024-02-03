using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class OrderUserFood
    {
        public int ID { get; set; }
        [Required, Range(1,100)]
        public int Quantity { get; set; }
        [ForeignKey("UserFood")]
        public int UserFoodID { get; set; }
        [Required, ForeignKey("Order")]
        public int OrderID { get; set; }
        public required UserFood UserFood { get; set; }
        public required Order Order { get; set; }
    }
}
