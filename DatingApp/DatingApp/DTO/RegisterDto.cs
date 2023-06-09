using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTO
{
    public class RegisterDto
    {
        [Required]
        public String? Username { get; set; }
        [Required]
        public String? Password { get; set; }
    }
}
