using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class OrderUserFood
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int UserFoodID { get; set; }
        public int OrderID { get; set; }
        public UserFood UserFood { get; set; }
        public Order Order { get; set; }
    }
}
