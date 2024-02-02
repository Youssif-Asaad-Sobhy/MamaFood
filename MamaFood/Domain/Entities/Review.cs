using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Review
    {
        public int ID { get; set; }
        [Range(1,5) , Required]
        public int Stars { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public User? User { get; set; }
        public Order? Order { get; set; }
    }
}
