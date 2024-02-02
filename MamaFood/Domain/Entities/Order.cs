using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }
        [ForeignKey("Review")]
        public int ReviewID { get; set; }
        public Review? Review { get; set; }
        public ICollection<OrderUserFood> OrderUserFoods { get; set; }
    }
}
