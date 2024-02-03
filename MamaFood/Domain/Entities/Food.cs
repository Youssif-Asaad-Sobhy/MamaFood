using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<UserFood> UserFoods { get; set; }
    }
}
