using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        public int Duration { get; set;}
        public int TotalPrice { get; set;}
        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }
        public required List<Food> Foods { get; set; }
        public SpecialRequest? SpecialRequest { get; set; }
        public Review? Review { get; set; }
    }
}
