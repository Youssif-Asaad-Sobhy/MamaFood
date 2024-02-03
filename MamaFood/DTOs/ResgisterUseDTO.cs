using MamaFood.API.Domain.Consts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.DTOs
{
    public class ResgisterUseDTO
    {
        [Required, DisplayName("User Name") ]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required, DisplayName("National ID")]
        public required string NID { get; set; }
        [Required]
        public required string Role { get; set; }
    }
}
