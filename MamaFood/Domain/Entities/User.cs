using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class User:IdentityUser
    {
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? NID { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
