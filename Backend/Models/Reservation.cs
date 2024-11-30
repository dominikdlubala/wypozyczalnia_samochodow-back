using System.Text.Json; 
using System.Text.Json.Serialization; 

namespace Backend.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual Car Car { get; set; } = null!;
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
    }
}
