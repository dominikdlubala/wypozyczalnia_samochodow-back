

namespace Backend.Models.DTOs
{
    public class AddReviewDTO
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public float StarsOutOfFive { get; set; }
        public string? ReviewContent { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now; 
    }
}
