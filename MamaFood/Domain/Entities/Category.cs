using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        [Required, StringLength(20), DataType(DataType.Text)]
        public string Name { get; set; }
        [StringLength(200), DataType(DataType.Text)]
        public string Description { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
