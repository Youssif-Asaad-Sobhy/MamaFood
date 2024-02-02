using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.Domain.Entities
{
    public class User:IdentityUser
    {
        [Required, StringLength(11)]
        public string PhoneNumber { get; set; }
        [Required, StringLength(14)]
        public string NID { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [StringLength(20)]
        public string? Name { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
