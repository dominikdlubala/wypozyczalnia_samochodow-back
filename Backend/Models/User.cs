using System.ComponentModel.DataAnnotations; 
using System.Text.Json; 
using System.Text.Json.Serialization; 


namespace Backend.Models; 

public class User {

    public int Id { get; set;}
    public string? FirstName { get; set;}    
    public string? LastName { get; set;}
    public DateTime RegistrationDate { get; set;} = DateTime.Now;

    // [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = null!;
    
    [Required(ErrorMessage = "Password is required")]
    public string Password {get; set; } = null!;
    public bool IsAdmin { get; set; } = false;
    [JsonIgnore]
    public virtual List<Car>? FavouriteCars { get; set;}
    [JsonIgnore]
    public virtual List<Reservation>? Reservations { get; set;}
    [JsonIgnore]
    public virtual List<Review>? Reviews { get; set;}
    [JsonIgnore]
    public virtual List<Fault>? ReportedFaults { get; set;}

}