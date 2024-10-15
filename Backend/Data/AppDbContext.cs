using Microsoft.EntityFrameworkCore; 
using Backend.Models; 

namespace Backend.Data; 

public class AppDbContext: DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    public DbSet<User> Users {get; set;}
    public DbSet<Car> Cars {get; set;}
    public DbSet<Fault> Faults {get; set;}
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Review> Reviews {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "johndoe", Password = "password123" },
            new User { Id = 2, Username = "janedoe", Password = "password456" },
            new User { Id = 3, Username = "admin", Password = "adminpass" }
        );
    }
}