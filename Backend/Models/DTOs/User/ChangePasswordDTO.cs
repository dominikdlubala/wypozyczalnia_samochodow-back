using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs.User
{
    public class ChangePasswordDTO
    {
        // Jeśli UserId jest niepotrzebny (można pobrać z kontekstu), usuń go
        // public int UserId { get; set; }

        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "Nowe hasło musi mieć co najmniej 8 znaków.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
