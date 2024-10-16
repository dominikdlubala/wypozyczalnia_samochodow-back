using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<float>(type: "real", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarUser",
                columns: table => new
                {
                    FavouriteCarsId = table.Column<int>(type: "int", nullable: false),
                    UsersFavouritesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarUser", x => new { x.FavouriteCarsId, x.UsersFavouritesId });
                    table.ForeignKey(
                        name: "FK_CarUser_Cars_FavouriteCarsId",
                        column: x => x.FavouriteCarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarUser_Users_UsersFavouritesId",
                        column: x => x.UsersFavouritesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedUserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faults_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faults_Users_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StarsOutOfFive = table.Column<float>(type: "real", nullable: false),
                    ReviewContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyType", "Brand", "Capacity", "Color", "FuelType", "ImageUrl", "Model", "PricePerDay", "ProductionYear" },
                values: new object[,]
                {
                    { 1, "Sedan", "Toyota", 1.6f, "Red", "Petrol", "/img1.jpg", "Corolla", 86f, 2017 },
                    { 2, "Hatchback", "Ford", 2.2f, "Blue", "Diesel", "/img2.jpg", "Focus", 140f, 2008 },
                    { 3, "Sedan", "Honda", 1.8f, "Blue", "Petrol", "/img3.jpg", "Civic", 37f, 2015 },
                    { 4, "SUV", "BMW", 3f, "Black", "Diesel", "/img4.jpg", "X5", 226f, 2010 },
                    { 5, "Kombi", "Audi", 1.4f, "Silver", "Petrol", "/img5.jpg", "A4", 185f, 2018 },
                    { 6, "Hatchback", "Volkswagen", 2f, "Black", "Diesel", "/img6.jpg", "Golf", 132f, 2016 },
                    { 7, "Sedan", "Mercedes", 1.6f, "White", "Petrol", "/img7.jpg", "C-Class", 321f, 2020 },
                    { 8, "Hatchback", "Opel", 1.7f, "Red", "Diesel", "/img8.jpg", "Astra", 61f, 2014 },
                    { 9, "Sedan", "Ford", 2f, "Silver", "Petrol", "/img9.jpg", "Mondeo", 156f, 2017 },
                    { 10, "Kombi", "Skoda", 1.9f, "Gray", "Diesel", "/img10.jpg", "Octavia", 86f, 2011 },
                    { 11, "Hatchback", "Renault", 1.6f, "Blue", "Petrol", "/img11.jpg", "Megane", 74f, 2013 },
                    { 12, "SUV", "Nissan", 2f, "Black", "Diesel", "/img12.jpg", "Qashqai", 181f, 2018 },
                    { 13, "Sedan", "Mazda", 2.5f, "Red", "Petrol", "/img13.jpg", "6", 148f, 2019 },
                    { 14, "Hatchback", "Peugeot", 1.6f, "Silver", "Diesel", "/img14.jpg", "308", 91f, 2015 },
                    { 15, "Kombi", "Volkswagen", 2f, "White", "Petrol", "/img15.jpg", "Passat", 238f, 2020 },
                    { 16, "Hatchback", "Fiat", 1.2f, "Yellow", "Petrol", "/img16.jpg", "500", 70f, 2018 },
                    { 17, "SUV", "Audi", 3f, "Black", "Diesel", "/img17.jpg", "Q7", 321f, 2017 },
                    { 18, "SUV", "Kia", 2f, "Blue", "Diesel", "/img18.jpg", "Sportage", 101f, 2016 },
                    { 19, "Hatchback", "Hyundai", 1.4f, "White", "Petrol", "/img19.jpg", "i30", 86f, 2018 },
                    { 20, "SUV", "Suzuki", 1.9f, "Green", "Diesel", "/img20.jpg", "Vitara", 136f, 2015 },
                    { 21, "Hatchback", "Citroen", 1.6f, "Silver", "Petrol", "/img21.jpg", "C4", 86f, 2016 },
                    { 22, "SUV", "Ford", 2f, "Red", "Diesel", "/img22.jpg", "Kuga", 169f, 2018 },
                    { 23, "Sedan", "BMW", 2f, "Gray", "Petrol", "/img23.jpg", "3 Series", 247f, 2021 },
                    { 24, "SUV", "Toyota", 2.2f, "Black", "Diesel", "/img24.jpg", "RAV4", 205f, 2018 },
                    { 25, "Sedan", "Honda", 2.4f, "White", "Petrol", "/img25.jpg", "Accord", 164f, 2017 },
                    { 26, "SUV", "Mazda", 2.2f, "Red", "Diesel", "/img26.jpg", "CX-5", 214f, 2019 },
                    { 27, "SUV", "Hyundai", 2f, "Silver", "Diesel", "/img27.jpg", "Tucson", 177f, 2017 },
                    { 28, "Hatchback", "Audi", 1.8f, "Blue", "Petrol", "/img28.jpg", "A3", 123f, 2016 },
                    { 29, "SUV", "Mercedes", 2.1f, "Black", "Diesel", "/img29.jpg", "GLC", 247f, 2020 },
                    { 30, "SUV", "Volkswagen", 2f, "White", "Diesel", "/img30.jpg", "Tiguan", 202f, 2019 },
                    { 31, "SUV", "Jeep", 3f, "Black", "Diesel", "/img31.jpg", "Grand Cherokee", 321f, 2019 },
                    { 32, "Hatchback", "Ford", 1f, "Blue", "Petrol", "/img32.jpg", "Fiesta", 82f, 2017 },
                    { 33, "Hatchback", "Toyota", 1.3f, "White", "Petrol", "/img33.jpg", "Yaris", 74f, 2016 },
                    { 34, "Hatchback", "Renault", 1.5f, "Red", "Diesel", "/img34.jpg", "Clio", 58f, 2015 },
                    { 35, "SUV", "BMW", 2f, "Silver", "Diesel", "/img35.jpg", "X3", 247f, 2020 },
                    { 36, "Convertible", "Mazda", 2f, "Red", "Petrol", "/img36.jpg", "MX-5", 185f, 2019 },
                    { 37, "Hatchback", "Volkswagen", 1f, "Blue", "Petrol", "/img37.jpg", "Polo", 70f, 2018 },
                    { 38, "SUV", "Honda", 2.2f, "Black", "Diesel", "/img38.jpg", "CR-V", 214f, 2017 },
                    { 39, "SUV", "Nissan", 1.6f, "Yellow", "Petrol", "/img39.jpg", "Juke", 86f, 2016 },
                    { 40, "SUV", "Peugeot", 1.6f, "Silver", "Diesel", "/img40.jpg", "2008", 103f, 2017 },
                    { 41, "Sedan", "Audi", 3.7f, "Black", "Petrol", "/img41.jpg", "A8", 514f, 2021 },
                    { 42, "SUV", "Porsche", 3.8f, "Red", "Petrol", "/img42.jpg", "Cayenne", 740f, 2020 },
                    { 43, "Sedan", "BMW", 4f, "White", "Petrol", "/img43.jpg", "M5", 575f, 2019 },
                    { 44, "Sedan", "Mercedes", 3.9f, "Silver", "Petrol", "/img44.jpg", "S-Class", 657f, 2020 },
                    { 45, "Convertible", "Jaguar", 3.8f, "Green", "Petrol", "/img45.jpg", "F-Type", 781f, 2021 },
                    { 46, "Coupe", "Ford", 3.7f, "Blue", "Petrol", "/img46.jpg", "Mustang", 548f, 2019 },
                    { 47, "Coupe", "Chevrolet", 3.6f, "Yellow", "Petrol", "/img47.jpg", "Camaro", 514f, 2018 },
                    { 48, "Sedan", "Dodge", 3.7f, "Black", "Petrol", "/img48.jpg", "Charger", 452f, 2019 },
                    { 49, "SUV", "Lexus", 3.5f, "White", "Petrol", "/img49.jpg", "RX 350", 390f, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "password1", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe" },
                    { 2, "Jane", "Smith", "password2", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith" },
                    { 3, "Alice", "Johnson", "password3", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson" },
                    { 4, "Bob", "Brown", "password4", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown" },
                    { 5, "Charlie", "Davis", "password5", new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis" },
                    { 6, "Emily", "White", "password6", new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.white" },
                    { 7, "David", "Miller", "password7", new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.miller" },
                    { 8, "Samantha", "Clark", "password8", new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "samantha.clark" },
                    { 9, "Michael", "Wilson", "password9", new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.wilson" },
                    { 10, "Olivia", "Martinez", "password10", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.martinez" },
                    { 11, "Lucas", "Garcia", "password11", new DateTime(2018, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.garcia" },
                    { 12, "Sophia", "Lopez", "password12", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.lopez" },
                    { 13, "James", "Thomas", "password13", new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.thomas" },
                    { 14, "Ava", "Moore", "password14", new DateTime(2021, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ava.moore" },
                    { 15, "Isabella", "Taylor", "password15", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.taylor" }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "CarId", "DateOfIssue", "Description", "ReportedUserId" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The engine makes a strange noise when accelerating.", 2 },
                    { 2, 10, new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The air conditioning doesn't work properly.", 4 },
                    { 3, 23, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car pulls to the right when braking.", 5 },
                    { 4, 27, new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Check engine light is on.", 7 },
                    { 5, 33, new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The rear suspension makes a creaking noise.", 8 },
                    { 6, 38, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car has difficulty starting in cold weather.", 10 },
                    { 7, 40, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The brakes feel spongy and unresponsive.", 11 },
                    { 8, 47, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The driver's side window is stuck and won't roll down.", 12 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "EndDate", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 2, 13, new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 13, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 4, 16, new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2021, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 1, new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 14, new DateTime(2021, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 8, 10, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 9, 2, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 3, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 19, new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 12, 16, new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "DateOfIssue", "ReviewContent", "StarsOutOfFive", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great car, very comfortable!", 4.5f, 1 },
                    { 2, 3, new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decent, but had some issues with the engine.", 3f, 2 },
                    { 3, 2, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perfect car for city driving.", 5f, 3 },
                    { 4, 4, new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not the best experience. The car was noisy.", 2.5f, 4 },
                    { 5, 5, new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good overall, but could be more fuel efficient.", 4f, 5 },
                    { 6, 1, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Okay, but I expected more from this model.", 3.5f, 6 },
                    { 7, 6, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Absolutely loved it!", 5f, 7 },
                    { 8, 7, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very reliable car for long distances.", 4.2f, 8 },
                    { 9, 8, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decent performance, but could be quieter.", 3.8f, 9 },
                    { 10, 9, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing car for the price.", 4.6f, 10 },
                    { 11, 10, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Had some mechanical issues.", 2.8f, 11 },
                    { 12, 11, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best car I've driven so far!", 4.9f, 12 },
                    { 13, 12, new DateTime(2019, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good for short trips, but not the best for long journeys.", 3.2f, 13 },
                    { 14, 13, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good handling and decent fuel economy.", 4.3f, 14 },
                    { 15, 14, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable but maintenance was expensive.", 3.7f, 15 },
                    { 16, 15, new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very satisfied with this car, will rent again!", 4.5f, 1 },
                    { 17, 16, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not bad, but it could use some improvements.", 2.9f, 2 },
                    { 18, 17, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exceeded my expectations.", 5f, 3 },
                    { 19, 18, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good, but had some minor issues.", 3.5f, 4 },
                    { 20, 19, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solid performance and very reliable.", 4f, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarUser_UsersFavouritesId",
                table: "CarUser",
                column: "UsersFavouritesId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_CarId",
                table: "Faults",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_ReportedUserId",
                table: "Faults",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarId",
                table: "Reviews",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarUser");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
