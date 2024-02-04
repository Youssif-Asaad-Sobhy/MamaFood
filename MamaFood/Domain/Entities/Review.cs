using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Review
    {
        public int ID { get; set; }
        public int Stars { get; set; }
        public string? Description { get; set; }
        public string Creator { get; set; }
        public int OrderId { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public Order Order { get; set; }
    }
}
