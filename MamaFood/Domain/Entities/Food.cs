using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Food
    {
        public int ID { get; set; }
        [Required, StringLength(20), DataType(DataType.Text)]
        public required string Name { get; set; }
        public byte[]? Photo { get; set; }

        public List<ApplicationUser>? Users { get; set; }
        public List<Order>? Orders { get; set; }
        public required Menu Menu { get; set; }
        public required Category Category { get; set; }
    }
}
