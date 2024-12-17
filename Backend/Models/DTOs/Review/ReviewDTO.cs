namespace Backend.Models.DTOs.Review
{
	public class ReviewDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Username { get; set; } = null!;
		public int CarId { get; set; }
		public float StarsOutOfFive { get; set; }
		public string? ReviewContent { get; set; }
		public DateTime DateOfIssue { get; set; }
	}
}
