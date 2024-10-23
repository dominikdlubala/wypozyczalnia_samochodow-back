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
        public DateTime? ReservationStart { get; set; }
        public DateTime? ReservationEnd { get; set; }
    }

}
