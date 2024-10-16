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

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Toyota", Model = "Corolla", ImageUrl = "/img1.jpg", FuelType = "Petrol", Capacity = 1.6f, BodyType = "Sedan", Color = "Red", PricePerDay = 86, ProductionYear = 2017 },
            new Car { Id = 2, Brand = "Ford", Model = "Focus", ImageUrl = "/img2.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "Hatchback", Color = "Blue", PricePerDay = 140, ProductionYear = 2008 },
            new Car { Id = 3, Brand = "Honda", Model = "Civic", ImageUrl = "/img3.jpg", FuelType = "Petrol", Capacity = 1.8f, BodyType = "Sedan", Color = "Blue", PricePerDay = 37, ProductionYear = 2015 },
            new Car { Id = 4, Brand = "BMW", Model = "X5", ImageUrl = "/img4.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Black", PricePerDay = 226, ProductionYear = 2010 },
            new Car { Id = 5, Brand = "Audi", Model = "A4", ImageUrl = "/img5.jpg", FuelType = "Petrol", Capacity = 1.4f, BodyType = "Kombi", Color = "Silver", PricePerDay = 185, ProductionYear = 2018 },
            new Car { Id = 6, Brand = "Volkswagen", Model = "Golf", ImageUrl = "/img6.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "Hatchback", Color = "Black", PricePerDay = 132, ProductionYear = 2016 },
            new Car { Id = 7, Brand = "Mercedes", Model = "C-Class", ImageUrl = "/img7.jpg", FuelType = "Petrol", Capacity = 1.6f, BodyType = "Sedan", Color = "White", PricePerDay = 321, ProductionYear = 2020 },
            new Car { Id = 8, Brand = "Opel", Model = "Astra", ImageUrl = "/img8.jpg", FuelType = "Diesel", Capacity = 1.7f, BodyType = "Hatchback", Color = "Red", PricePerDay = 61, ProductionYear = 2014 },
            new Car { Id = 9, Brand = "Ford", Model = "Mondeo", ImageUrl = "/img9.jpg", FuelType = "Petrol", Capacity = 2.0f, BodyType = "Sedan", Color = "Silver", PricePerDay = 156, ProductionYear = 2017 },
            new Car { Id = 10, Brand = "Skoda", Model = "Octavia", ImageUrl = "/img10.jpg", FuelType = "Diesel", Capacity = 1.9f, BodyType = "Kombi", Color = "Gray", PricePerDay = 86, ProductionYear = 2011 },
            new Car { Id = 11, Brand = "Renault", Model = "Megane", ImageUrl = "/img11.jpg", FuelType = "Petrol", Capacity = 1.6f, BodyType = "Hatchback", Color = "Blue", PricePerDay = 74, ProductionYear = 2013 },
            new Car { Id = 12, Brand = "Nissan", Model = "Qashqai", ImageUrl = "/img12.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Black", PricePerDay = 181, ProductionYear = 2018 },
            new Car { Id = 13, Brand = "Mazda", Model = "6", ImageUrl = "/img13.jpg", FuelType = "Petrol", Capacity = 2.5f, BodyType = "Sedan", Color = "Red", PricePerDay = 148, ProductionYear = 2019 },
            new Car { Id = 14, Brand = "Peugeot", Model = "308", ImageUrl = "/img14.jpg", FuelType = "Diesel", Capacity = 1.6f, BodyType = "Hatchback", Color = "Silver", PricePerDay = 91, ProductionYear = 2015 },
            new Car { Id = 15, Brand = "Volkswagen", Model = "Passat", ImageUrl = "/img15.jpg", FuelType = "Petrol", Capacity = 2.0f, BodyType = "Kombi", Color = "White", PricePerDay = 238, ProductionYear = 2020 },
            new Car { Id = 16, Brand = "Fiat", Model = "500", ImageUrl = "/img16.jpg", FuelType = "Petrol", Capacity = 1.2f, BodyType = "Hatchback", Color = "Yellow", PricePerDay = 70, ProductionYear = 2018 },
            new Car { Id = 17, Brand = "Audi", Model = "Q7", ImageUrl = "/img17.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Black", PricePerDay = 321, ProductionYear = 2017 },
            new Car { Id = 18, Brand = "Kia", Model = "Sportage", ImageUrl = "/img18.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Blue", PricePerDay = 101, ProductionYear = 2016 },
            new Car { Id = 19, Brand = "Hyundai", Model = "i30", ImageUrl = "/img19.jpg", FuelType = "Petrol", Capacity = 1.4f, BodyType = "Hatchback", Color = "White", PricePerDay = 86, ProductionYear = 2018 },
            new Car { Id = 20, Brand = "Suzuki", Model = "Vitara", ImageUrl = "/img20.jpg", FuelType = "Diesel", Capacity = 1.9f, BodyType = "SUV", Color = "Green", PricePerDay = 136, ProductionYear = 2015 },
            new Car { Id = 21, Brand = "Citroen", Model = "C4", ImageUrl = "/img21.jpg", FuelType = "Petrol", Capacity = 1.6f, BodyType = "Hatchback", Color = "Silver", PricePerDay = 86, ProductionYear = 2016 },
            new Car { Id = 22, Brand = "Ford", Model = "Kuga", ImageUrl = "/img22.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Red", PricePerDay = 169, ProductionYear = 2018 },
            new Car { Id = 23, Brand = "BMW", Model = "3 Series", ImageUrl = "/img23.jpg", FuelType = "Petrol", Capacity = 2.0f, BodyType = "Sedan", Color = "Gray", PricePerDay = 247, ProductionYear = 2021 },
            new Car { Id = 24, Brand = "Toyota", Model = "RAV4", ImageUrl = "/img24.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Black", PricePerDay = 205, ProductionYear = 2018 },
            new Car { Id = 25, Brand = "Honda", Model = "Accord", ImageUrl = "/img25.jpg", FuelType = "Petrol", Capacity = 2.4f, BodyType = "Sedan", Color = "White", PricePerDay = 164, ProductionYear = 2017 },
            new Car { Id = 26, Brand = "Mazda", Model = "CX-5", ImageUrl = "/img26.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Red", PricePerDay = 214, ProductionYear = 2019 },
            new Car { Id = 27, Brand = "Hyundai", Model = "Tucson", ImageUrl = "/img27.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Silver", PricePerDay = 177, ProductionYear = 2017 },
            new Car { Id = 28, Brand = "Audi", Model = "A3", ImageUrl = "/img28.jpg", FuelType = "Petrol", Capacity = 1.8f, BodyType = "Hatchback", Color = "Blue", PricePerDay = 123, ProductionYear = 2016 },
            new Car { Id = 29, Brand = "Mercedes", Model = "GLC", ImageUrl = "/img29.jpg", FuelType = "Diesel", Capacity = 2.1f, BodyType = "SUV", Color = "Black", PricePerDay = 247, ProductionYear = 2020 },
            new Car { Id = 30, Brand = "Volkswagen", Model = "Tiguan", ImageUrl = "/img30.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "White", PricePerDay = 202, ProductionYear = 2019 },
            new Car { Id = 31, Brand = "Jeep", Model = "Grand Cherokee", ImageUrl = "/img31.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Black", PricePerDay = 321, ProductionYear = 2019 },
            new Car { Id = 32, Brand = "Ford", Model = "Fiesta", ImageUrl = "/img32.jpg", FuelType = "Petrol", Capacity = 1.0f, BodyType = "Hatchback", Color = "Blue", PricePerDay = 82, ProductionYear = 2017 },
            new Car { Id = 33, Brand = "Toyota", Model = "Yaris", ImageUrl = "/img33.jpg", FuelType = "Petrol", Capacity = 1.3f, BodyType = "Hatchback", Color = "White", PricePerDay = 74, ProductionYear = 2016 },
            new Car { Id = 34, Brand = "Renault", Model = "Clio", ImageUrl = "/img34.jpg", FuelType = "Diesel", Capacity = 1.5f, BodyType = "Hatchback", Color = "Red", PricePerDay = 58, ProductionYear = 2015 },
            new Car { Id = 35, Brand = "BMW", Model = "X3", ImageUrl = "/img35.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Silver", PricePerDay = 247, ProductionYear = 2020 },
            new Car { Id = 36, Brand = "Mazda", Model = "MX-5", ImageUrl = "/img36.jpg", FuelType = "Petrol", Capacity = 2.0f, BodyType = "Convertible", Color = "Red", PricePerDay = 185, ProductionYear = 2019 },
            new Car { Id = 37, Brand = "Volkswagen", Model = "Polo", ImageUrl = "/img37.jpg", FuelType = "Petrol", Capacity = 1.0f, BodyType = "Hatchback", Color = "Blue", PricePerDay = 70, ProductionYear = 2018 },
            new Car { Id = 38, Brand = "Honda", Model = "CR-V", ImageUrl = "/img38.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Black", PricePerDay = 214, ProductionYear = 2017 },
            new Car { Id = 39, Brand = "Nissan", Model = "Juke", ImageUrl = "/img39.jpg", FuelType = "Petrol", Capacity = 1.6f, BodyType = "SUV", Color = "Yellow", PricePerDay = 86, ProductionYear = 2016 },
            new Car { Id = 40, Brand = "Peugeot", Model = "2008", ImageUrl = "/img40.jpg", FuelType = "Diesel", Capacity = 1.6f, BodyType = "SUV", Color = "Silver", PricePerDay = 103, ProductionYear = 2017 },
            new Car { Id = 41, Brand = "Audi", Model = "A8", ImageUrl = "/img41.jpg", FuelType = "Petrol", Capacity = 3.7f, BodyType = "Sedan", Color = "Black", PricePerDay = 514, ProductionYear = 2021 },
            new Car { Id = 42, Brand = "Porsche", Model = "Cayenne", ImageUrl = "/img42.jpg", FuelType = "Petrol", Capacity = 3.8f, BodyType = "SUV", Color = "Red", PricePerDay = 740, ProductionYear = 2020 },
            new Car { Id = 43, Brand = "BMW", Model = "M5", ImageUrl = "/img43.jpg", FuelType = "Petrol", Capacity = 4.0f, BodyType = "Sedan", Color = "White", PricePerDay = 575, ProductionYear = 2019 },
            new Car { Id = 44, Brand = "Mercedes", Model = "S-Class", ImageUrl = "/img44.jpg", FuelType = "Petrol", Capacity = 3.9f, BodyType = "Sedan", Color = "Silver", PricePerDay = 657, ProductionYear = 2020 },
            new Car { Id = 45, Brand = "Jaguar", Model = "F-Type", ImageUrl = "/img45.jpg", FuelType = "Petrol", Capacity = 3.8f, BodyType = "Convertible", Color = "Green", PricePerDay = 781, ProductionYear = 2021 },
            new Car { Id = 46, Brand = "Ford", Model = "Mustang", ImageUrl = "/img46.jpg", FuelType = "Petrol", Capacity = 3.7f, BodyType = "Coupe", Color = "Blue", PricePerDay = 548, ProductionYear = 2019 },
            new Car { Id = 47, Brand = "Chevrolet", Model = "Camaro", ImageUrl = "/img47.jpg", FuelType = "Petrol", Capacity = 3.6f, BodyType = "Coupe", Color = "Yellow", PricePerDay = 514, ProductionYear = 2018 },
            new Car { Id = 48, Brand = "Dodge", Model = "Charger", ImageUrl = "/img48.jpg", FuelType = "Petrol", Capacity = 3.7f, BodyType = "Sedan", Color = "Black", PricePerDay = 452, ProductionYear = 2019 },
            new Car { Id = 49, Brand = "Lexus", Model = "RX 350", ImageUrl = "/img49.jpg", FuelType = "Petrol", Capacity = 3.5f, BodyType = "SUV", Color = "White", PricePerDay = 390, ProductionYear = 2020 }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "john.doe", Password = "password1", FirstName = "John", LastName = "Doe", RegistrationDate = new DateTime(2021, 6, 1) },
            new User { Id = 2, Username = "jane.smith", Password = "password2", FirstName = "Jane", LastName = "Smith", RegistrationDate = new DateTime(2020, 8, 15) },
            new User { Id = 3, Username = "alice.johnson", Password = "password3", FirstName = "Alice", LastName = "Johnson", RegistrationDate = new DateTime(2022, 3, 20) },
            new User { Id = 4, Username = "bob.brown", Password = "password4", FirstName = "Bob", LastName = "Brown", RegistrationDate = new DateTime(2019, 11, 5) },
            new User { Id = 5, Username = "charlie.davis", Password = "password5", FirstName = "Charlie", LastName = "Davis", RegistrationDate = new DateTime(2021, 2, 10) },
            new User { Id = 6, Username = "emily.white", Password = "password6", FirstName = "Emily", LastName = "White", RegistrationDate = new DateTime(2020, 7, 23) },
            new User { Id = 7, Username = "david.miller", Password = "password7", FirstName = "David", LastName = "Miller", RegistrationDate = new DateTime(2019, 12, 1) },
            new User { Id = 8, Username = "samantha.clark", Password = "password8", FirstName = "Samantha", LastName = "Clark", RegistrationDate = new DateTime(2021, 1, 11) },
            new User { Id = 9, Username = "michael.wilson", Password = "password9", FirstName = "Michael", LastName = "Wilson", RegistrationDate = new DateTime(2020, 6, 18) },
            new User { Id = 10, Username = "olivia.martinez", Password = "password10", FirstName = "Olivia", LastName = "Martinez", RegistrationDate = new DateTime(2022, 2, 22) },
            new User { Id = 11, Username = "lucas.garcia", Password = "password11", FirstName = "Lucas", LastName = "Garcia", RegistrationDate = new DateTime(2018, 9, 9) },
            new User { Id = 12, Username = "sophia.lopez", Password = "password12", FirstName = "Sophia", LastName = "Lopez", RegistrationDate = new DateTime(2021, 10, 15) },
            new User { Id = 13, Username = "james.thomas", Password = "password13", FirstName = "James", LastName = "Thomas", RegistrationDate = new DateTime(2020, 3, 5) },
            new User { Id = 14, Username = "ava.moore", Password = "password14", FirstName = "Ava", LastName = "Moore", RegistrationDate = new DateTime(2021, 7, 29) },
            new User { Id = 15, Username = "isabella.taylor", Password = "password15", FirstName = "Isabella", LastName = "Taylor", RegistrationDate = new DateTime(2019, 8, 20) }
        );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, UserId = 1, CarId = 1, StarsOutOfFive = 4.5f, ReviewContent = "Great car, very comfortable!", DateOfIssue = new DateTime(2021, 7, 10) },
            new Review { Id = 2, UserId = 2, CarId = 3, StarsOutOfFive = 3.0f, ReviewContent = "Decent, but had some issues with the engine.", DateOfIssue = new DateTime(2020, 11, 25) },
            new Review { Id = 3, UserId = 3, CarId = 2, StarsOutOfFive = 5.0f, ReviewContent = "Perfect car for city driving.", DateOfIssue = new DateTime(2022, 1, 12) },
            new Review { Id = 4, UserId = 4, CarId = 4, StarsOutOfFive = 2.5f, ReviewContent = "Not the best experience. The car was noisy.", DateOfIssue = new DateTime(2019, 9, 3) },
            new Review { Id = 5, UserId = 5, CarId = 5, StarsOutOfFive = 4.0f, ReviewContent = "Good overall, but could be more fuel efficient.", DateOfIssue = new DateTime(2021, 4, 18) },
            new Review { Id = 6, UserId = 6, CarId = 1, StarsOutOfFive = 3.5f, ReviewContent = "Okay, but I expected more from this model.", DateOfIssue = new DateTime(2020, 6, 30) },
            new Review { Id = 7, UserId = 7, CarId = 6, StarsOutOfFive = 5.0f, ReviewContent = "Absolutely loved it!", DateOfIssue = new DateTime(2022, 2, 22) },
            new Review { Id = 8, UserId = 8, CarId = 7, StarsOutOfFive = 4.2f, ReviewContent = "Very reliable car for long distances.", DateOfIssue = new DateTime(2021, 12, 1) },
            new Review { Id = 9, UserId = 9, CarId = 8, StarsOutOfFive = 3.8f, ReviewContent = "Decent performance, but could be quieter.", DateOfIssue = new DateTime(2021, 5, 5) },
            new Review { Id = 10, UserId = 10, CarId = 9, StarsOutOfFive = 4.6f, ReviewContent = "Amazing car for the price.", DateOfIssue = new DateTime(2022, 3, 18) },
            new Review { Id = 11, UserId = 11, CarId = 10, StarsOutOfFive = 2.8f, ReviewContent = "Had some mechanical issues.", DateOfIssue = new DateTime(2020, 8, 14) },
            new Review { Id = 12, UserId = 12, CarId = 11, StarsOutOfFive = 4.9f, ReviewContent = "Best car I've driven so far!", DateOfIssue = new DateTime(2021, 10, 21) },
            new Review { Id = 13, UserId = 13, CarId = 12, StarsOutOfFive = 3.2f, ReviewContent = "Good for short trips, but not the best for long journeys.", DateOfIssue = new DateTime(2019, 7, 6) },
            new Review { Id = 14, UserId = 14, CarId = 13, StarsOutOfFive = 4.3f, ReviewContent = "Good handling and decent fuel economy.", DateOfIssue = new DateTime(2020, 12, 29) },
            new Review { Id = 15, UserId = 15, CarId = 14, StarsOutOfFive = 3.7f, ReviewContent = "Comfortable but maintenance was expensive.", DateOfIssue = new DateTime(2021, 9, 9) },
            new Review { Id = 16, UserId = 1, CarId = 15, StarsOutOfFive = 4.5f, ReviewContent = "Very satisfied with this car, will rent again!", DateOfIssue = new DateTime(2022, 5, 15) },
            new Review { Id = 17, UserId = 2, CarId = 16, StarsOutOfFive = 2.9f, ReviewContent = "Not bad, but it could use some improvements.", DateOfIssue = new DateTime(2021, 3, 30) },
            new Review { Id = 18, UserId = 3, CarId = 17, StarsOutOfFive = 5.0f, ReviewContent = "Exceeded my expectations.", DateOfIssue = new DateTime(2022, 7, 8) },
            new Review { Id = 19, UserId = 4, CarId = 18, StarsOutOfFive = 3.5f, ReviewContent = "Good, but had some minor issues.", DateOfIssue = new DateTime(2020, 10, 22) },
            new Review { Id = 20, UserId = 5, CarId = 19, StarsOutOfFive = 4.0f, ReviewContent = "Solid performance and very reliable.", DateOfIssue = new DateTime(2021, 6, 12) }
        );

        modelBuilder.Entity<Fault>().HasData(
            new Fault { Id = 1, ReportedUserId = 2, CarId = 5, Description = "The engine makes a strange noise when accelerating.", DateOfIssue = new DateTime(2021, 7, 10) },
            new Fault { Id = 2, ReportedUserId = 4, CarId = 10, Description = "The air conditioning doesn't work properly.", DateOfIssue = new DateTime(2020, 11, 25) },
            new Fault { Id = 3, ReportedUserId = 5, CarId = 23, Description = "The car pulls to the right when braking.", DateOfIssue = new DateTime(2022, 1, 12) },
            new Fault { Id = 4, ReportedUserId = 7, CarId = 27, Description = "Check engine light is on.", DateOfIssue = new DateTime(2019, 9, 3) },
            new Fault { Id = 5, ReportedUserId = 8, CarId = 33, Description = "The rear suspension makes a creaking noise.", DateOfIssue = new DateTime(2021, 4, 18) },
            new Fault { Id = 6, ReportedUserId = 10, CarId = 38, Description = "The car has difficulty starting in cold weather.", DateOfIssue = new DateTime(2020, 6, 30) },
            new Fault { Id = 7, ReportedUserId = 11, CarId = 40, Description = "The brakes feel spongy and unresponsive.", DateOfIssue = new DateTime(2022, 2, 22) },
            new Fault { Id = 8, ReportedUserId = 12, CarId = 47, Description = "The driver's side window is stuck and won't roll down.", DateOfIssue = new DateTime(2021, 12, 1) }
        );

        modelBuilder.Entity<Reservation>().HasData(
            new Reservation { Id = 1, UserId = 8, CarId = 9, StartDate = new DateTime(2021, 2, 2), EndDate = new DateTime(2021, 2, 4) },
            new Reservation { Id = 2, UserId = 3, CarId = 13, StartDate = new DateTime(2021, 3, 16), EndDate = new DateTime(2021, 3, 18) },
            new Reservation { Id = 3, UserId = 7, CarId = 13, StartDate = new DateTime(2021, 12, 11), EndDate = new DateTime(2021, 12, 17) },
            new Reservation { Id = 4, UserId = 4, CarId = 16, StartDate = new DateTime(2021, 10, 2), EndDate = new DateTime(2021, 10, 6) },
            new Reservation { Id = 5, UserId = 1, CarId = 5, StartDate = new DateTime(2021, 7, 8), EndDate = new DateTime(2021, 7, 13) },
            new Reservation { Id = 6, UserId = 6, CarId = 1, StartDate = new DateTime(2021, 8, 16), EndDate = new DateTime(2021, 8, 23) },
            new Reservation { Id = 7, UserId = 10, CarId = 14, StartDate = new DateTime(2021, 12, 27), EndDate = new DateTime(2021, 12, 29) },
            new Reservation { Id = 8, UserId = 10, CarId = 10, StartDate = new DateTime(2021, 5, 15), EndDate = new DateTime(2021, 5, 19) },
            new Reservation { Id = 9, UserId = 1, CarId = 2, StartDate = new DateTime(2021, 8, 4), EndDate = new DateTime(2021, 8, 10) },
            new Reservation { Id = 10, UserId = 1, CarId = 3, StartDate = new DateTime(2021, 2, 19), EndDate = new DateTime(2021, 2, 25) },
            new Reservation { Id = 11, UserId = 15, CarId = 19, StartDate = new DateTime(2021, 10, 5), EndDate = new DateTime(2021, 10, 8) },
            new Reservation { Id = 12, UserId = 5, CarId = 16, StartDate = new DateTime(2021, 7, 7), EndDate = new DateTime(2021, 7, 9) }
        );
    
    }
}