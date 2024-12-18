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

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserId); 

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CarId); 

        modelBuilder.Entity<Review>()
        .HasOne(r => r.User)
        .WithMany(u => u.Reviews)
        .HasForeignKey(r => r.UserId);


        modelBuilder.Entity<Review>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CarId);


        modelBuilder.Entity<Fault>()
            .HasOne(f => f.ReportedUser)
            .WithMany(u => u.ReportedFaults)
            .HasForeignKey(f => f.ReportedUserId);


        modelBuilder.Entity<Fault>()
            .HasOne(f => f.Car)
            .WithMany(c => c.Faults)
            .HasForeignKey(f => f.CarId);
            
        modelBuilder.Entity<User>()
            .HasMany(u => u.FavouriteCars)
            .WithMany(c => c.UsersFavourites)
            .UsingEntity(j => j.ToTable("UserFavouriteCars"));          
        
        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Toyota", Model = "Corolla", ImageUrl = "/img1.jpg", FuelType = "Benzyna", Capacity = 1.6f, BodyType = "Kombi", Color = "Biały", PricePerDay = 370, ProductionYear = 2017 },
            new Car { Id = 2, Brand = "Ford", Model = "Focus", ImageUrl = "/img2.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "Hatchback", Color = "Niebieski", PricePerDay = 320, ProductionYear = 2020},
            new Car { Id = 3, Brand = "Honda", Model = "Civic", ImageUrl = "/img3.jpg", FuelType = "Benzyna", Capacity = 1.8f, BodyType = "Hatchback", Color = "Czerwony", PricePerDay = 110, ProductionYear = 2007},
            new Car { Id = 4, Brand = "BMW", Model = "X5", ImageUrl = "/img4.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Czarny", PricePerDay = 226, ProductionYear = 2010 },
            new Car { Id = 5, Brand = "Audi", Model = "A4", ImageUrl = "/img5.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Sedan", Color = "Czarny", PricePerDay = 415, ProductionYear = 2018 },
            new Car { Id = 6, Brand = "Volkswagen", Model = "Golf", ImageUrl = "/img6.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "Hatchback", Color = "Niebieski", PricePerDay = 290, ProductionYear = 2016 },
            new Car { Id = 7, Brand = "Mercedes", Model = "C-Class", ImageUrl = "/img7.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Sedan", Color = "Czerwony", PricePerDay = 470, ProductionYear = 2020 },
            new Car { Id = 8, Brand = "Opel", Model = "Astra", ImageUrl = "/img8.jpg", FuelType = "Diesel", Capacity = 1.7f, BodyType = "Hatchback", Color = "Niebieski", PricePerDay = 260, ProductionYear = 2014 },
            new Car { Id = 9, Brand = "Ford", Model = "Mondeo", ImageUrl = "/img9.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Sedan", Color = "Czerwony", PricePerDay = 330, ProductionYear = 2017 },
            new Car { Id = 10, Brand = "Skoda", Model = "Octavia", ImageUrl = "/img10.jpg", FuelType = "Diesel", Capacity = 1.9f, BodyType = "Kombi", Color = "Srebrny", PricePerDay = 215, ProductionYear = 2011 },
            new Car { Id = 11, Brand = "Renault", Model = "Megane", ImageUrl = "/img11.jpg", FuelType = "Benzyna", Capacity = 1.6f, BodyType = "Hatchback", Color = "Żółty", PricePerDay = 450, ProductionYear = 2018 },
            new Car { Id = 12, Brand = "Nissan", Model = "Qashqai", ImageUrl = "/img12.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Niebieski", PricePerDay = 390, ProductionYear = 2018 },
            new Car { Id = 13, Brand = "Mazda", Model = "6", ImageUrl = "/img13.jpg", FuelType = "Benzyna", Capacity = 2.5f, BodyType = "Sedan", Color = "Czerwony", PricePerDay = 520, ProductionYear = 2019 },
            new Car { Id = 14, Brand = "Peugeot", Model = "308", ImageUrl = "/img14.jpg", FuelType = "Diesel", Capacity = 1.6f, BodyType = "Kombi", Color = "Szary", PricePerDay = 300, ProductionYear = 2015 },
            new Car { Id = 15, Brand = "Volkswagen", Model = "Passat", ImageUrl = "/img15.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Kombi", Color = "Biały", PricePerDay = 550, ProductionYear = 2020 },
            new Car { Id = 16, Brand = "Fiat", Model = "500", ImageUrl = "/img16.jpg", FuelType = "Benzyna", Capacity = 1.2f, BodyType = "Hatchback", Color = "Biały", PricePerDay = 370, ProductionYear = 2018 },
            new Car { Id = 17, Brand = "Audi", Model = "Q7", ImageUrl = "/img17.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Czarny", PricePerDay = 590, ProductionYear = 2017 },
            new Car { Id = 18, Brand = "Kia", Model = "Sportage", ImageUrl = "/img18.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Biały", PricePerDay = 440, ProductionYear = 2016 },
            new Car { Id = 19, Brand = "Hyundai", Model = "i30", ImageUrl = "/img19.jpg", FuelType = "Benzyna", Capacity = 1.4f, BodyType = "Hatchback", Color = "Niebieski", PricePerDay = 620, ProductionYear = 2018 },
            new Car { Id = 20, Brand = "Suzuki", Model = "Vitara", ImageUrl = "/img20.jpg", FuelType = "Diesel", Capacity = 1.9f, BodyType = "SUV", Color = "Czerwony", PricePerDay = 380, ProductionYear = 2015 },
            new Car { Id = 21, Brand = "Citroen", Model = "C4", ImageUrl = "/img21.jpg", FuelType = "Benzyna", Capacity = 1.6f, BodyType = "SUV", Color = "Pomarańczowy", PricePerDay = 500, ProductionYear = 2021 },
            new Car { Id = 22, Brand = "Ford", Model = "Kuga", ImageUrl = "/img22.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Czarny", PricePerDay = 460, ProductionYear = 2018 },
            new Car { Id = 23, Brand = "BMW", Model = "Seria 3", ImageUrl = "/img23.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Sedan", Color = "Szary", PricePerDay = 660, ProductionYear = 2021 },
            new Car { Id = 24, Brand = "Toyota", Model = "RAV4", ImageUrl = "/img24.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Czerwony", PricePerDay = 540, ProductionYear = 2018 },
            new Car { Id = 25, Brand = "Honda", Model = "Accord", ImageUrl = "/img25.jpg", FuelType = "Benzyna", Capacity = 2.4f, BodyType = "Sedan", Color = "Czerwony", PricePerDay = 410, ProductionYear = 2017 },
            new Car { Id = 26, Brand = "Mazda", Model = "CX-5", ImageUrl = "/img26.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Czerwony", PricePerDay = 565, ProductionYear = 2019 },
            new Car { Id = 27, Brand = "Hyundai", Model = "Tucson", ImageUrl = "/img27.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Granatowy", PricePerDay = 370, ProductionYear = 2017 },
            new Car { Id = 28, Brand = "Audi", Model = "A3", ImageUrl = "/img28.jpg", FuelType = "Benzyna", Capacity = 1.8f, BodyType = "Hatchback", Color = "Czerwony", PricePerDay = 450, ProductionYear = 2016 },
            new Car { Id = 29, Brand = "Mercedes", Model = "GLC", ImageUrl = "/img29.jpg", FuelType = "Diesel", Capacity = 2.1f, BodyType = "SUV", Color = "Srebrny", PricePerDay = 600, ProductionYear = 2020 },
            new Car { Id = 30, Brand = "Volkswagen", Model = "Tiguan", ImageUrl = "/img30.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Szary", PricePerDay = 550, ProductionYear = 2019 },
            new Car { Id = 31, Brand = "Jeep", Model = "Grand Cherokee", ImageUrl = "/img31.jpg", FuelType = "Diesel", Capacity = 3.0f, BodyType = "SUV", Color = "Czerwony", PricePerDay = 530, ProductionYear = 2019 },
            new Car { Id = 32, Brand = "Ford", Model = "Fiesta", ImageUrl = "/img32.jpg", FuelType = "Benzyna", Capacity = 1.0f, BodyType = "Hatchback", Color = "Niebieski", PricePerDay = 325, ProductionYear = 2017 },
            new Car { Id = 33, Brand = "Toyota", Model = "Yaris", ImageUrl = "/img33.jpg", FuelType = "Benzyna", Capacity = 1.3f, BodyType = "Hatchback", Color = "Czerwony", PricePerDay = 300, ProductionYear = 2016 },
            new Car { Id = 34, Brand = "Renault", Model = "Clio", ImageUrl = "/img34.jpg", FuelType = "Diesel", Capacity = 1.5f, BodyType = "Kombi", Color = "Czerwony", PricePerDay = 440, ProductionYear = 2015 },
            new Car { Id = 35, Brand = "BMW", Model = "X3", ImageUrl = "/img35.jpg", FuelType = "Diesel", Capacity = 2.0f, BodyType = "SUV", Color = "Czarny", PricePerDay = 620, ProductionYear = 2020 },
            new Car { Id = 36, Brand = "Mazda", Model = "MX-5", ImageUrl = "/img36.jpg", FuelType = "Benzyna", Capacity = 2.0f, BodyType = "Kabriolet", Color = "Czerwony", PricePerDay = 660, ProductionYear = 2019 },
            new Car { Id = 37, Brand = "Volkswagen", Model = "Polo", ImageUrl = "/img37.jpg", FuelType = "Benzyna", Capacity = 1.0f, BodyType = "Hatchback", Color = "Szary", PricePerDay = 470, ProductionYear = 2018 },
            new Car { Id = 38, Brand = "Honda", Model = "CR-V", ImageUrl = "/img38.jpg", FuelType = "Diesel", Capacity = 2.2f, BodyType = "SUV", Color = "Szary", PricePerDay = 510, ProductionYear = 2017 },
            new Car { Id = 39, Brand = "Nissan", Model = "Juke", ImageUrl = "/img39.jpg", FuelType = "Benzyna", Capacity = 1.6f, BodyType = "SUV", Color = "Czerwony", PricePerDay = 530, ProductionYear = 2016 },
            new Car { Id = 40, Brand = "Peugeot", Model = "2008", ImageUrl = "/img40.jpg", FuelType = "Diesel", Capacity = 1.6f, BodyType = "SUV", Color = "Biały", PricePerDay = 420, ProductionYear = 2017 },
            new Car { Id = 41, Brand = "Audi", Model = "A8", ImageUrl = "/img41.jpg", FuelType = "Benzyna", Capacity = 3.7f, BodyType = "Sedan", Color = "Czarny ", PricePerDay = 770, ProductionYear = 2021 },
            new Car { Id = 42, Brand = "Porsche", Model = "Cayenne", ImageUrl = "/img42.jpg", FuelType = "Benzyna", Capacity = 3.8f, BodyType = "SUV", Color = "Szary", PricePerDay = 950, ProductionYear = 2020 },
            new Car { Id = 43, Brand = "BMW", Model = "M5", ImageUrl = "/img43.jpg", FuelType = "Benzyna", Capacity = 4.0f, BodyType = "Sedan", Color = "Czarny", PricePerDay = 1100, ProductionYear = 2019 },
            new Car { Id = 44, Brand = "Mercedes", Model = "S-Class", ImageUrl = "/img44.jpg", FuelType = "Benzyna", Capacity = 3.9f, BodyType = "Sedan", Color = "Srebrny", PricePerDay = 850, ProductionYear = 2020 },
            new Car { Id = 45, Brand = "Jaguar", Model = "F-Type", ImageUrl = "/img45.jpg", FuelType = "Benzyna", Capacity = 3.8f, BodyType = "Coupe", Color = "Niebieski", PricePerDay = 1350, ProductionYear = 2021 },
            new Car { Id = 46, Brand = "Ford", Model = "Mustang", ImageUrl = "/img46.jpg", FuelType = "Benzyna", Capacity = 3.7f, BodyType = "Coupe", Color = "Zielony", PricePerDay = 830, ProductionYear = 2019 },
            new Car { Id = 47, Brand = "Chevrolet", Model = "Camaro", ImageUrl = "/img47.jpg", FuelType = "Benzyna", Capacity = 3.6f, BodyType = "Coupe", Color = "Srebrny", PricePerDay = 900, ProductionYear = 2018 },
            new Car { Id = 48, Brand = "Dodge", Model = "Charger", ImageUrl = "/img48.jpg", FuelType = "Benzyna", Capacity = 3.7f, BodyType = "Sedan", Color = "Zielony", PricePerDay = 1200, ProductionYear = 2019 },
            new Car { Id = 49, Brand = "Lexus", Model = "RX 350", ImageUrl = "/img49.jpg", FuelType = "Benzyna", Capacity = 3.5f, BodyType = "SUV", Color = "Szary", PricePerDay = 990, ProductionYear = 2020 }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "admin", FirstName = "admin", LastName = "admin", RegistrationDate = new DateTime(2021, 6, 1), Email = "admin@gmail.com", IsAdmin = true },
            new User { Id = 2, Username = "john.doe", Password = "password1", FirstName = "John", LastName = "Doe", RegistrationDate = new DateTime(2021, 6, 1), Email = "john.doe@gmail.com" },
            new User { Id = 3, Username = "jane.smith", Password = "password2", FirstName = "Jane", LastName = "Smith", RegistrationDate = new DateTime(2020, 8, 15), Email = "jane.smith@gmail.com" },
            new User { Id = 4, Username = "bob.brown", Password = "password4", FirstName = "Bob", LastName = "Brown", RegistrationDate = new DateTime(2019, 11, 5), Email = "bob.brown@gmail.com" },
            new User { Id = 5, Username = "charlie.davis", Password = "password5", FirstName = "Charlie", LastName = "Davis", RegistrationDate = new DateTime(2021, 2, 10), Email = "charlie.davis@gmail.com" },
            new User { Id = 6, Username = "emily.white", Password = "password6", FirstName = "Emily", LastName = "White", RegistrationDate = new DateTime(2020, 7, 23), Email = "emily.white@gmail.com" },
            new User { Id = 7, Username = "david.miller", Password = "password7", FirstName = "David", LastName = "Miller", RegistrationDate = new DateTime(2019, 12, 1), Email = "david.miller@gmail.com" },
            new User { Id = 8, Username = "samantha.clark", Password = "password8", FirstName = "Samantha", LastName = "Clark", RegistrationDate = new DateTime(2021, 1, 11), Email = "samantha.clark@gmail.com" },
            new User { Id = 9, Username = "michael.wilson", Password = "password9", FirstName = "Michael", LastName = "Wilson", RegistrationDate = new DateTime(2020, 6, 18), Email = "michael.wilson@gmail.com" },
            new User { Id = 10, Username = "olivia.martinez", Password = "password10", FirstName = "Olivia", LastName = "Martinez", RegistrationDate = new DateTime(2022, 2, 22), Email = "olivia.martinez@gmail.com" },
            new User { Id = 11, Username = "lucas.garcia", Password = "password11", FirstName = "Lucas", LastName = "Garcia", RegistrationDate = new DateTime(2018, 9, 9), Email = "lucas.garcia@gmail.com" },
            new User { Id = 12, Username = "sophia.lopez", Password = "password12", FirstName = "Sophia", LastName = "Lopez", RegistrationDate = new DateTime(2021, 10, 15), Email = "sophia.lopez@gmail.com" },
            new User { Id = 13, Username = "james.thomas", Password = "password13", FirstName = "James", LastName = "Thomas", RegistrationDate = new DateTime(2020, 3, 5), Email = "james.thomas@gmail.com" },
            new User { Id = 14, Username = "ava.moore", Password = "password14", FirstName = "Ava", LastName = "Moore", RegistrationDate = new DateTime(2021, 7, 29), Email = "ava.moore@gmail.com" },
            new User { Id = 15, Username = "isabella.taylor", Password = "password15", FirstName = "Isabella", LastName = "Taylor", RegistrationDate = new DateTime(2019, 8, 20), Email = "isabella.taylor@gmail.com" },
            new User { Id = 16, Username = "alice.johnson", Password = "password3", FirstName = "Alice", LastName = "Johnson", RegistrationDate = new DateTime(2022, 3, 20), Email = "alice.johnson@gmail.com" }
        );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, UserId = 2, CarId = 1, StarsOutOfFive = 4.5f, ReviewContent = "Świetne auto, bardzo wygodne!", DateOfIssue = new DateTime(2021, 7, 10) },
            new Review { Id = 6, UserId = 6, CarId = 1, StarsOutOfFive = 3.5f, ReviewContent = "W porządku, ale oczekiwałem czegoś więcej od tego modelu.", DateOfIssue = new DateTime(2020, 6, 30) },
            new Review { Id = 3, UserId = 3, CarId = 2, StarsOutOfFive = 5.0f, ReviewContent = "Idealne auto do jazdy po mieście.", DateOfIssue = new DateTime(2022, 1, 12) },
            new Review { Id = 2, UserId = 2, CarId = 3, StarsOutOfFive = 3.0f, ReviewContent = "Przyzwoite, ale miało problemy z silnikiem.", DateOfIssue = new DateTime(2020, 11, 25) },
            new Review { Id = 4, UserId = 4, CarId = 4, StarsOutOfFive = 2.5f, ReviewContent = "Niezbyt dobre doświadczenie. Auto było głośne.", DateOfIssue = new DateTime(2019, 9, 3) },
            new Review { Id = 5, UserId = 5, CarId = 5, StarsOutOfFive = 4.0f, ReviewContent = "Ogólnie dobre, ale mogłoby być bardziej oszczędne.", DateOfIssue = new DateTime(2021, 4, 18) },
            new Review { Id = 7, UserId = 7, CarId = 6, StarsOutOfFive = 5.0f, ReviewContent = "Absolutnie je uwielbiam!", DateOfIssue = new DateTime(2022, 2, 22) },
            new Review { Id = 8, UserId = 8, CarId = 7, StarsOutOfFive = 4.2f, ReviewContent = "Bardzo niezawodne auto na długie trasy.", DateOfIssue = new DateTime(2021, 12, 1) },
            new Review { Id = 9, UserId = 9, CarId = 8, StarsOutOfFive = 3.5f, ReviewContent = "Przyzwoita wydajność, ale mogłoby być cichsze.", DateOfIssue = new DateTime(2021, 5, 5) },
            new Review { Id = 10, UserId = 10, CarId = 9, StarsOutOfFive = 4.5f, ReviewContent = "Świetne auto w tej cenie.", DateOfIssue = new DateTime(2022, 3, 18) },
            new Review { Id = 11, UserId = 11, CarId = 10, StarsOutOfFive = 3.0f, ReviewContent = "Miało pewne problemy mechaniczne.", DateOfIssue = new DateTime(2020, 8, 14) },
            new Review { Id = 12, UserId = 12, CarId = 11, StarsOutOfFive = 5.0f, ReviewContent = "Najlepsze auto, jakim jeździłem!", DateOfIssue = new DateTime(2021, 10, 21) },
            new Review { Id = 13, UserId = 13, CarId = 12, StarsOutOfFive = 3.5f, ReviewContent = "Dobre na krótkie trasy, ale nie najlepsze na długie podróże.", DateOfIssue = new DateTime(2019, 7, 6) },
            new Review { Id = 14, UserId = 14, CarId = 13, StarsOutOfFive = 4.0f, ReviewContent = "Dobre prowadzenie i przyzwoita ekonomia paliwa.", DateOfIssue = new DateTime(2020, 12, 29) },
            new Review { Id = 15, UserId = 15, CarId = 14, StarsOutOfFive = 3.5f, ReviewContent = "Wygodne, ale dosyć wolne.", DateOfIssue = new DateTime(2021, 9, 9) },
            new Review { Id = 16, UserId = 2, CarId = 15, StarsOutOfFive = 4.5f, ReviewContent = "Jestem bardzo zadowolony, na pewno wynajmę ponownie!", DateOfIssue = new DateTime(2022, 5, 15) },
            new Review { Id = 17, UserId = 2, CarId = 16, StarsOutOfFive = 3.0f, ReviewContent = "Nieźle, ale mogłoby być lepsze.", DateOfIssue = new DateTime(2021, 3, 30) },
            new Review { Id = 18, UserId = 3, CarId = 17, StarsOutOfFive = 5.0f, ReviewContent = "Przekroczyło moje oczekiwania.", DateOfIssue = new DateTime(2022, 7, 8) },
            new Review { Id = 19, UserId = 4, CarId = 18, StarsOutOfFive = 3.5f, ReviewContent = "Dobre, ale miało drobne problemy.", DateOfIssue = new DateTime(2020, 10, 22) },
            new Review { Id = 20, UserId = 5, CarId = 19, StarsOutOfFive = 4.0f, ReviewContent = "Solidne osiągi i bardzo niezawodne.", DateOfIssue = new DateTime(2021, 6, 12) },
            new Review { Id = 21, UserId = 2, CarId = 20, StarsOutOfFive = 4.5f, ReviewContent = "Świetne auto, bardzo komfortowe!", DateOfIssue = new DateTime(2021, 7, 10) },
            new Review { Id = 22, UserId = 2, CarId = 21, StarsOutOfFive = 3.0f, ReviewContent = "Przyzwoite, ale miało problemy z silnikiem.", DateOfIssue = new DateTime(2020, 11, 25) },
            new Review { Id = 23, UserId = 3, CarId = 22, StarsOutOfFive = 5.0f, ReviewContent = "Idealne auto do jazdy po mieście.", DateOfIssue = new DateTime(2022, 1, 12) },
            new Review { Id = 24, UserId = 4, CarId = 23, StarsOutOfFive = 2.5f, ReviewContent = "Nie najlepsze doświadczenie. Samochód był głośny.", DateOfIssue = new DateTime(2019, 9, 3) },
            new Review { Id = 25, UserId = 5, CarId = 24, StarsOutOfFive = 4.0f, ReviewContent = "Dobre auto, ale spalanie mogłoby być niższe.", DateOfIssue = new DateTime(2021, 4, 18) },
            new Review { Id = 26, UserId = 6, CarId = 25, StarsOutOfFive = 3.5f, ReviewContent = "Oczekiwałem czegoś więcej, ale jest w porządku.", DateOfIssue = new DateTime(2020, 6, 30) },
            new Review { Id = 27, UserId = 7, CarId = 26, StarsOutOfFive = 5.0f, ReviewContent = "Uwielbiam ten samochód, idealny na dłuższe podróże!", DateOfIssue = new DateTime(2022, 2, 22) },
            new Review { Id = 28, UserId = 8, CarId = 27, StarsOutOfFive = 4.5f, ReviewContent = "Bardzo wygodne i niezawodne auto.", DateOfIssue = new DateTime(2021, 12, 1) },
            new Review { Id = 29, UserId = 9, CarId = 28, StarsOutOfFive = 3.5f, ReviewContent = "Dobra wydajność, ale nieco głośny silnik.", DateOfIssue = new DateTime(2021, 5, 5) },
            new Review { Id = 30, UserId = 10, CarId = 29, StarsOutOfFive = 4.5f, ReviewContent = "Świetny stosunek jakości do ceny.", DateOfIssue = new DateTime(2022, 3, 18) },
            new Review { Id = 31, UserId = 11, CarId = 30, StarsOutOfFive = 3.0f, ReviewContent = "Samochód miał kilka problemów mechanicznych.", DateOfIssue = new DateTime(2020, 8, 14) },
            new Review { Id = 32, UserId = 12, CarId = 31, StarsOutOfFive = 5.0f, ReviewContent = "Najlepszy samochód, jakim kiedykolwiek jeździłem!", DateOfIssue = new DateTime(2021, 10, 21) },
            new Review { Id = 33, UserId = 13, CarId = 32, StarsOutOfFive = 3.5f, ReviewContent = "Dobre na krótkie trasy, ale długie podróże są męczące.", DateOfIssue = new DateTime(2019, 7, 6) },
            new Review { Id = 34, UserId = 14, CarId = 33, StarsOutOfFive = 4.0f, ReviewContent = "Auto dobrze się prowadzi i jest ekonomiczne.", DateOfIssue = new DateTime(2020, 12, 29) },
            new Review { Id = 35, UserId = 15, CarId = 34, StarsOutOfFive = 3.5f, ReviewContent = "Wygodny, ale zbyt głośny.", DateOfIssue = new DateTime(2021, 9, 9) },
            new Review { Id = 36, UserId = 2, CarId = 35, StarsOutOfFive = 4.5f, ReviewContent = "Bardzo zadowolony, wynajmę ponownie!", DateOfIssue = new DateTime(2022, 5, 15) },
            new Review { Id = 37, UserId = 2, CarId = 36, StarsOutOfFive = 3.0f, ReviewContent = "Nieźle, ale można by kilka rzeczy poprawić.", DateOfIssue = new DateTime(2021, 3, 30) },
            new Review { Id = 38, UserId = 3, CarId = 37, StarsOutOfFive = 5.0f, ReviewContent = "Auto przekroczyło moje oczekiwania.", DateOfIssue = new DateTime(2022, 7, 8) },
            new Review { Id = 39, UserId = 4, CarId = 38, StarsOutOfFive = 3.5f, ReviewContent = "Dobre auto, ale drobne problemy były widoczne.", DateOfIssue = new DateTime(2020, 10, 22) },
            new Review { Id = 40, UserId = 5, CarId = 39, StarsOutOfFive = 4.0f, ReviewContent = "Solidny samochód, niezawodny na trasie.", DateOfIssue = new DateTime(2021, 6, 12) },
            new Review { Id = 41, UserId = 3, CarId = 40, StarsOutOfFive = 4.5f, ReviewContent = "Fantastyczny SUV, gorąco polecam!", DateOfIssue = new DateTime(2021, 8, 14) },
            new Review { Id = 42, UserId = 5, CarId = 41, StarsOutOfFive = 3.5f, ReviewContent = "Całkiem niezły, ale nie idealny.", DateOfIssue = new DateTime(2022, 1, 3) },
            new Review { Id = 43, UserId = 6, CarId = 42, StarsOutOfFive = 5.0f, ReviewContent = "Idealny na rodzinne wycieczki!", DateOfIssue = new DateTime(2022, 6, 18) },
            new Review { Id = 44, UserId = 7, CarId = 43, StarsOutOfFive = 5.0f, ReviewContent = "Niesamowite osiągi i prowadzenie.", DateOfIssue = new DateTime(2022, 9, 1) },
            new Review { Id = 45, UserId = 8, CarId = 44, StarsOutOfFive = 4.0f, ReviewContent = "Luksusowy samochód, wart swojej ceny.", DateOfIssue = new DateTime(2021, 11, 15) },
            new Review { Id = 46, UserId = 9, CarId = 45, StarsOutOfFive = 5.0f, ReviewContent = "Najlepsze coupe, jakim jeździłem.", DateOfIssue = new DateTime(2022, 4, 20) },
            new Review { Id = 47, UserId = 10, CarId = 46, StarsOutOfFive = 4.5f, ReviewContent = "Mocny silnik i piękny wygląd.", DateOfIssue = new DateTime(2021, 10, 8) },
            new Review { Id = 48, UserId = 11, CarId = 47, StarsOutOfFive = 4.0f, ReviewContent = "Agresywny design i solidne osiągi.", DateOfIssue = new DateTime(2022, 3, 1) },
            new Review { Id = 49, UserId = 12, CarId = 48, StarsOutOfFive = 4.5f, ReviewContent = "Niezapomniane doświadczenie z autem typu muscle.", DateOfIssue = new DateTime(2021, 12, 10) },
            new Review { Id = 50, UserId = 13, CarId = 49, StarsOutOfFive = 4.0f, ReviewContent = "Przestronne i komfortowe dla całej rodziny.", DateOfIssue = new DateTime(2022, 5, 25) }
        );

        modelBuilder.Entity<Reservation>().HasData(
            new Reservation { Id = 1, UserId = 8, CarId = 9, StartDate = new DateTime(2021, 2, 2), EndDate = new DateTime(2021, 2, 4) },
            new Reservation { Id = 2, UserId = 3, CarId = 13, StartDate = new DateTime(2021, 3, 16), EndDate = new DateTime(2021, 3, 18) },
            new Reservation { Id = 3, UserId = 7, CarId = 13, StartDate = new DateTime(2021, 12, 11), EndDate = new DateTime(2021, 12, 17) },
            new Reservation { Id = 4, UserId = 4, CarId = 16, StartDate = new DateTime(2021, 10, 2), EndDate = new DateTime(2021, 10, 6) },
            new Reservation { Id = 5, UserId = 2, CarId = 5, StartDate = new DateTime(2021, 7, 8), EndDate = new DateTime(2021, 7, 13) },
            new Reservation { Id = 6, UserId = 6, CarId = 1, StartDate = new DateTime(2021, 8, 16), EndDate = new DateTime(2021, 8, 23) },
            new Reservation { Id = 7, UserId = 10, CarId = 14, StartDate = new DateTime(2021, 12, 27), EndDate = new DateTime(2021, 12, 29) },
            new Reservation { Id = 8, UserId = 10, CarId = 10, StartDate = new DateTime(2021, 5, 15), EndDate = new DateTime(2021, 5, 19) },
            new Reservation { Id = 9, UserId = 2, CarId = 2, StartDate = new DateTime(2021, 8, 4), EndDate = new DateTime(2021, 8, 10) },
            new Reservation { Id = 10, UserId = 3, CarId = 3, StartDate = new DateTime(2021, 2, 19), EndDate = new DateTime(2021, 2, 25) },
            new Reservation { Id = 11, UserId = 15, CarId = 19, StartDate = new DateTime(2021, 10, 5), EndDate = new DateTime(2021, 10, 8) },
            new Reservation { Id = 12, UserId = 5, CarId = 16, StartDate = new DateTime(2021, 7, 7), EndDate = new DateTime(2021, 7, 9) }
        );
    }
}