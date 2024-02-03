using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        #region Foreign Keys
        public required string UserID { get; set; }
        #endregion
        #region Navigation Property
        public required ApplicationUser User { get; set; }
        public Review? Review { get; set; }
        public required ICollection<OrderUserFood> OrderUserFoods { get; set; }
        #endregion
    }
}
