using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MamaFood.API.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Stars { get; set; }
        public string? Description { get; set; }
        #region Foreign Key
        public required string Creator { get; set; }
        public int OrderId { get; set; }
        #endregion

        #region Navigation property
        public required ApplicationUser User { get; set; }
        public required Order Order { get; set; }
        #endregion
    }
}
