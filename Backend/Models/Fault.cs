namespace Backend.Models
{
    public class Fault
    {
        public int Id { get; set; }
        public int ReportedUserId { get; set; }
        public int CardId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }

        public virtual Car Car { get; set; }
        public virtual User ReportedUser { get; set; }
    }
}
