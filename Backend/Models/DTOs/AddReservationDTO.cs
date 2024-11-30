namespace Backend.Models.DTOs
{
    public class AddReservationDTO
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
