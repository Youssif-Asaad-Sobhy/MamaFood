using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class OrderFood
    {
        public int ID { get; set; }
        [Required, Range(1,100)]
        public int Quantity { get; set; }
        [ForeignKey("UserFood")]
        public int FoodID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public UserFood? UserFood { get; set; }
        public Order? Order { get; set; }
    }
}
