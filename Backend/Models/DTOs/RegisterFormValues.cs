using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs
{
    public class RegisterFormValues
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
