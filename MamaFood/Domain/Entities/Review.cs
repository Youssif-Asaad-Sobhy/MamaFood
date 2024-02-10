using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Review
    {
        public int ID { get; set; }
        [Range(1, 5), Required]
        public int Stars { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public required string CreatorId { get; set; }
        public required int OrderID { get; set; }
        public required ApplicationUser User { get; set; }
        public required Order Order { get; set; }
    }
}
