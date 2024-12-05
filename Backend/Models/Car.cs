using System.Text.Json; 
using System.Text.Json.Serialization; 

namespace Backend.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? ImageUrl  { get; set; }
        public string? FuelType { get; set; }
        public float Capacity { get; set; }
        public string? BodyType {  get; set; }
        public string? Color {  get; set; }
        public float PricePerDay { get; set; }
        public int ProductionYear { get; set; }

        [JsonIgnore]
        public virtual List<User>? UsersFavourites { get; set; }

        public virtual List<Reservation>? Reservations { get; set; }
        [JsonIgnore]
        public virtual List<Fault>? Faults { get; set; }
        [JsonIgnore]
        public virtual List<Review>? Reviews { get; set; }
    }
}
