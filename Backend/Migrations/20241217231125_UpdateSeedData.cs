using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Kombi", "Biały", "Benzyna", 370f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "PricePerDay", "ProductionYear" },
                values: new object[] { "Niebieski", 320f, 2020 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "Hatchback", "Czerwony", "Benzyna", 110f, 2007 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "Czarny");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BodyType", "Capacity", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Sedan", 2f, "Czarny", "Benzyna", 415f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Niebieski", 290f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacity", "Color", "FuelType", "PricePerDay" },
                values: new object[] { 2f, "Czerwony", "Benzyna", 470f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Niebieski", 260f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 330f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Srebrny", 215f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "Żółty", "Benzyna", 450f, 2018 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Niebieski", 390f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 520f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BodyType", "Color", "PricePerDay" },
                values: new object[] { "Kombi", "Szary", 300f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Biały", "Benzyna", 550f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Biały", "Benzyna", 370f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czarny", 590f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Biały", 440f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Niebieski", "Benzyna", 620f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czerwony", 380f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "SUV", "Pomarańczowy", "Benzyna", 500f, 2021 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czarny", 460f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Color", "FuelType", "Model", "PricePerDay" },
                values: new object[] { "Szary", "Benzyna", "Seria 3", 660f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czerwony", 540f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 410f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czerwony", 565f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Granatowy", 370f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 450f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Srebrny", 600f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Szary", 550f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czerwony", 530f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Niebieski", "Benzyna", 325f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 300f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BodyType", "Color", "PricePerDay" },
                values: new object[] { "Kombi", "Czerwony", 440f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Czarny", 620f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Kabriolet", "Czerwony", "Benzyna", 660f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Szary", "Benzyna", 470f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Szary", 510f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czerwony", "Benzyna", 530f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Biały", 420f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czarny ", "Benzyna", 770f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Szary", "Benzyna", 950f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Czarny", "Benzyna", 1100f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Srebrny", "Benzyna", 850f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Coupe", "Niebieski", "Benzyna", 1350f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Zielony", "Benzyna", 830f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Srebrny", "Benzyna", 900f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Zielony", "Benzyna", 1200f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Szary", "Benzyna", 990f });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReviewContent", "UserId" },
                values: new object[] { "Świetne auto, bardzo wygodne!", 2 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewContent",
                value: "Przyzwoite, ale miało problemy z silnikiem.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewContent",
                value: "Idealne auto do jazdy po mieście.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReviewContent",
                value: "Niezbyt dobre doświadczenie. Auto było głośne.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReviewContent",
                value: "Ogólnie dobre, ale mogłoby być bardziej oszczędne.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReviewContent",
                value: "W porządku, ale oczekiwałem czegoś więcej od tego modelu.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReviewContent",
                value: "Absolutnie je uwielbiam!");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReviewContent",
                value: "Bardzo niezawodne auto na długie trasy.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Przyzwoita wydajność, ale mogłoby być cichsze.", 3.5f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Świetne auto w tej cenie.", 4.5f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Miało pewne problemy mechaniczne.", 3f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Najlepsze auto, jakim jeździłem!", 5f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Dobre na krótkie trasy, ale nie najlepsze na długie podróże.", 3.5f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Dobre prowadzenie i przyzwoita ekonomia paliwa.", 4f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Wygodne, ale dosyć wolne.", 3.5f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ReviewContent", "UserId" },
                values: new object[] { "Jestem bardzo zadowolony, na pewno wynajmę ponownie!", 2 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Nieźle, ale mogłoby być lepsze.", 3f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "ReviewContent",
                value: "Przekroczyło moje oczekiwania.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "ReviewContent",
                value: "Dobre, ale miało drobne problemy.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "ReviewContent",
                value: "Solidne osiągi i bardzo niezawodne.");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "DateOfIssue", "ReviewContent", "StarsOutOfFive", "UserId" },
                values: new object[,]
                {
                    { 21, 20, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Świetne auto, bardzo komfortowe!", 4.5f, 2 },
                    { 22, 21, new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przyzwoite, ale miało problemy z silnikiem.", 3f, 2 },
                    { 23, 22, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Idealne auto do jazdy po mieście.", 5f, 3 },
                    { 24, 23, new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nie najlepsze doświadczenie. Samochód był głośny.", 2.5f, 4 },
                    { 25, 24, new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobre auto, ale spalanie mogłoby być niższe.", 4f, 5 },
                    { 26, 25, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oczekiwałem czegoś więcej, ale jest w porządku.", 3.5f, 6 },
                    { 27, 26, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uwielbiam ten samochód, idealny na dłuższe podróże!", 5f, 7 },
                    { 28, 27, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bardzo wygodne i niezawodne auto.", 4.5f, 8 },
                    { 29, 28, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobra wydajność, ale nieco głośny silnik.", 3.5f, 9 },
                    { 30, 29, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Świetny stosunek jakości do ceny.", 4.5f, 10 },
                    { 31, 30, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samochód miał kilka problemów mechanicznych.", 3f, 11 },
                    { 32, 31, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najlepszy samochód, jakim kiedykolwiek jeździłem!", 5f, 12 },
                    { 33, 32, new DateTime(2019, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobre na krótkie trasy, ale długie podróże są męczące.", 3.5f, 13 },
                    { 34, 33, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auto dobrze się prowadzi i jest ekonomiczne.", 4f, 14 },
                    { 35, 34, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wygodny, ale zbyt głośny.", 3.5f, 15 },
                    { 36, 35, new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bardzo zadowolony, wynajmę ponownie!", 4.5f, 2 },
                    { 37, 36, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieźle, ale można by kilka rzeczy poprawić.", 3f, 2 },
                    { 38, 37, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auto przekroczyło moje oczekiwania.", 5f, 3 },
                    { 39, 38, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobre auto, ale drobne problemy były widoczne.", 3.5f, 4 },
                    { 40, 39, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solidny samochód, niezawodny na trasie.", 4f, 5 },
                    { 41, 40, new DateTime(2021, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastyczny SUV, gorąco polecam!", 4.5f, 3 },
                    { 42, 41, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Całkiem niezły, ale nie idealny.", 3.5f, 5 },
                    { 43, 42, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Idealny na rodzinne wycieczki!", 5f, 6 },
                    { 44, 43, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niesamowite osiągi i prowadzenie.", 5f, 7 },
                    { 45, 44, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luksusowy samochód, wart swojej ceny.", 4f, 8 },
                    { 46, 45, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najlepsze coupe, jakim jeździłem.", 5f, 9 },
                    { 47, 46, new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mocny silnik i piękny wygląd.", 4.5f, 10 },
                    { 48, 47, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agresywny design i solidne osiągi.", 4f, 11 },
                    { 49, 48, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niezapomniane doświadczenie z autem typu muscle.", 4.5f, 12 },
                    { 50, 49, new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przestronne i komfortowe dla całej rodziny.", 4f, 13 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { "admin@gmail.com", "admin", "admin", "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[] { "john.doe@gmail.com", "John", "Doe", "password1", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[] { "jane.smith@gmail.com", "Jane", "Smith", "password2", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "bob.brown@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "charlie.davis@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "emily.white@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Email",
                value: "david.miller@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Email",
                value: "samantha.clark@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Email",
                value: "michael.wilson@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Email",
                value: "olivia.martinez@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Email",
                value: "lucas.garcia@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Email",
                value: "sophia.lopez@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Email",
                value: "james.thomas@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: "ava.moore@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Email",
                value: "isabella.taylor@gmail.com");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[] { 16, "alice.johnson@gmail.com", "Alice", false, "Johnson", "password3", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Sedan", "Red", "Petrol", 86f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "PricePerDay", "ProductionYear" },
                values: new object[] { "Blue", 140f, 2008 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "Sedan", "Blue", "Petrol", 37f, 2015 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BodyType", "Capacity", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Kombi", 1.4f, "Silver", "Petrol", 185f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 132f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacity", "Color", "FuelType", "PricePerDay" },
                values: new object[] { 1.6f, "White", "Petrol", 321f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Red", 61f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Silver", "Petrol", 156f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Gray", 86f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "Blue", "Petrol", 74f, 2013 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 181f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Red", "Petrol", 148f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BodyType", "Color", "PricePerDay" },
                values: new object[] { "Hatchback", "Silver", 91f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 238f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Yellow", "Petrol", 70f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 321f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Blue", 101f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 86f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Green", 136f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay", "ProductionYear" },
                values: new object[] { "Hatchback", "Silver", "Petrol", 86f, 2016 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Red", 169f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Color", "FuelType", "Model", "PricePerDay" },
                values: new object[] { "Gray", "Petrol", "3 Series", 247f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 205f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 164f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Red", 214f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Silver", 177f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Blue", "Petrol", 123f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 247f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "White", 202f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 321f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Blue", "Petrol", 82f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 74f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BodyType", "Color", "PricePerDay" },
                values: new object[] { "Hatchback", "Red", 58f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Silver", 247f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Convertible", "Red", "Petrol", 185f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Blue", "Petrol", 70f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Black", 214f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Yellow", "Petrol", 86f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Color", "PricePerDay" },
                values: new object[] { "Silver", 103f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Black", "Petrol", 514f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Red", "Petrol", 740f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 575f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Silver", "Petrol", 657f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BodyType", "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Convertible", "Green", "Petrol", 781f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Blue", "Petrol", 548f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Yellow", "Petrol", 514f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "Black", "Petrol", 452f });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Color", "FuelType", "PricePerDay" },
                values: new object[] { "White", "Petrol", 390f });

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

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReviewContent", "UserId" },
                values: new object[] { "Great car, very comfortable!", 1 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewContent",
                value: "Decent, but had some issues with the engine.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewContent",
                value: "Perfect car for city driving.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReviewContent",
                value: "Not the best experience. The car was noisy.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReviewContent",
                value: "Good overall, but could be more fuel efficient.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReviewContent",
                value: "Okay, but I expected more from this model.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReviewContent",
                value: "Absolutely loved it!");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReviewContent",
                value: "Very reliable car for long distances.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Decent performance, but could be quieter.", 3.8f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Amazing car for the price.", 4.6f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Had some mechanical issues.", 2.8f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Best car I've driven so far!", 4.9f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Good for short trips, but not the best for long journeys.", 3.2f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Good handling and decent fuel economy.", 4.3f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Comfortable but maintenance was expensive.", 3.7f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ReviewContent", "UserId" },
                values: new object[] { "Very satisfied with this car, will rent again!", 1 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ReviewContent", "StarsOutOfFive" },
                values: new object[] { "Not bad, but it could use some improvements.", 2.9f });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "ReviewContent",
                value: "Exceeded my expectations.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "ReviewContent",
                value: "Good, but had some minor issues.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "ReviewContent",
                value: "Solid performance and very reliable.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { null, "John", "Doe", "password1", "john.doe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[] { null, "Jane", "Smith", "password2", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName", "Password", "RegistrationDate", "Username" },
                values: new object[] { null, "Alice", "Johnson", "password3", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Email",
                value: null);
        }
    }
}
