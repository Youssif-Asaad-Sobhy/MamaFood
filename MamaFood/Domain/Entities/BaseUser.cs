using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class BaseUser:IdentityUser
    {
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? NID { get; set; }
        public string? Describtin { get; set; }
        [Required]
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
    }
}
