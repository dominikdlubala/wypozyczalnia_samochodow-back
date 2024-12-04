using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs
{
    public class UpdateUserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        [EmailAddress]
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
