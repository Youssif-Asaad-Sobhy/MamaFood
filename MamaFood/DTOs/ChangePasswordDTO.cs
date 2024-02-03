using System.ComponentModel.DataAnnotations;

namespace MamaFood.API.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public required string OldPassword {  get; set; }
        [Required]
        public required string NewPassword {  get; set; }
    }
}
