namespace Backend.Models.DTOs.Car
{
    public class AddOrEditCarDTO
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string FuelType { get; set; } = null!;
        public float Capacity { get; set; }
        public string BodyType { get; set; } = null!;
        public string Color { get; set; } = null!;
        public float PricePerDay { get; set; }
        public int ProductionYear { get; set; }
    }
}
