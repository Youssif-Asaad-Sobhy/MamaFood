using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.DTOs
{
    public class LogInUserDTO
    {
        [Required]
        public required string UserName {  get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
