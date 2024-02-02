using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Food
    {
        public int ID { get; set; }
        [Required,StringLength(20), DataType(DataType.Text)]
        public string Name { get; set; }
        public Byte[] Photo { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
