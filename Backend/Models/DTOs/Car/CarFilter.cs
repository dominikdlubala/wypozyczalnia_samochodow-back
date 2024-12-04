namespace Backend.Models.DTOs
{
    public class CarFilter
    {
        public string? EngineType { get; set; }
        public string? Displacement { get; set; }
        public string? BodyType { get; set; }
        public string? Colour { get; set; }
        public string? PriceMin { get; set; }
        public string? PriceMax { get; set; }
        public string? YearMin { get; set; }
        public string? YearMax { get; set; }

        // Daty w formacie ISO 8601 (yyyy-MM-ddTHH:mm:ss)
        // Przykładowo 2024-10-25T12:00:00
        public DateTime? ReservationStart { get; set; } 
        public DateTime? ReservationEnd { get; set; }
    }

}
