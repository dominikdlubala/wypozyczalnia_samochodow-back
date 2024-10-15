namespace Backend.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public float StarsOutOfFive { get; set; }
        public string? ReviewContent { get; set; }
        public DateTime DateOfIssue { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
