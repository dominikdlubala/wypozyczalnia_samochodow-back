using System.ComponentModel.DataAnnotations; 

namespace Backend.Models; 

public class User {

    public int Id {get; set;}
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set;}
    [Required(ErrorMessage = "Password is required")]
    public string Password {get; set;}

    public virtual List<Car>? FavouriteCars { get; set;}
    public virtual List<Reservation>? Reservations { get; set;}
    public virtual List<Review>? Reviews { get; set;}
    public virtual List<Fault>? ReportedFaults { get; set;}


}