namespace Backend.Models.DTOs.Review
{
    public class EditReviewDTO
    {
        public float StarsOutOfFive { get; set; }
        public string ReviewContent { get; set; } = null!;
    }
}
