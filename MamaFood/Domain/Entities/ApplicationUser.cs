using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(14)]
        public required string NID { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Required, StringLength(20)]
        public required string Name { get; set; }
        public byte[]? Photo { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}
