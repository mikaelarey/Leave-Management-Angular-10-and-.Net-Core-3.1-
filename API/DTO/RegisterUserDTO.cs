using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be minimum of 4 characters and maximum of 20 characters.")]
        public string Password { get; set; }
    }
}