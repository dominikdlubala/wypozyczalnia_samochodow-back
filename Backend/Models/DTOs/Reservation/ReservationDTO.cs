using Backend.Models.DTOs.Car;

namespace Backend.Models.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CarDTO Car { get; set; } = null!;
    }
}
