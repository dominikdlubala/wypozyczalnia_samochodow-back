namespace Backend.Models.DTOs.Fault
{
	public class AddFaultDTO
	{
		public int CarId {  get; set; }
		public string Description { get; set; } = null!;
	}
}
