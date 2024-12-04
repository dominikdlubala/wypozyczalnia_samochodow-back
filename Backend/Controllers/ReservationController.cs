using System.Net;
using System.Security.Claims;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Car;
using Backend.Models.DTOs.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _context.Reservations
                    .Include(r => r.User)
                    .Include(r => r.Car)
                    .Select(r => new
                    {
                        r.Id,
                        r.UserId,
                        UserName = $"{r.User.FirstName} {r.User.LastName}",
                        r.CarId,
                        CarName = $"{r.Car.Brand} {r.Car.Model}",
                        r.StartDate,
                        r.EndDate
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Nie udało się pobrać rezerwacji", error = e.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            try {
                var reservation = await _context.Reservations.FindAsync(id);

                if (reservation == null)
                {
                    return NotFound();
                }

                return Ok(reservation);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [Authorize]
        [HttpPost("user")]
        public async Task<IActionResult> GetUserReservations()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return BadRequest("User ID not found.");
                }

                int userId = Int32.Parse(userIdClaim);
                var reservations = await _context.Reservations
                    .Include(r => r.Car) // Dołączenie danych o samochodzie
                    .Where(r => r.UserId == userId)
                    .Select(r => new ReservationDTO
                    {
                        Id = r.Id,
                        StartDate = r.StartDate,
                        EndDate = r.EndDate,
                        Car = new CarDTO
                        {
                            Id = r.Car.Id,
                            Model = r.Car.Model,
                            Brand = r.Car.Brand,
                            ImageUrl = r.Car.ImageUrl,
                            FuelType = r.Car.FuelType,
                            Capacity = r.Car.Capacity,
                            BodyType = r.Car.BodyType,
                            Color = r.Car.Color,
                            PricePerDay = r.Car.PricePerDay,
                            ProductionYear = r.Car.ProductionYear
                        }
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationDTO newReservation)
        {
            try {
                if (newReservation == null)
                {
                    return BadRequest("Reservation object is null");
                }

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; 
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return BadRequest("User ID not found.");
                }
                var userId = Int32.Parse(userIdClaim); 
                var car = await _context.Cars.FindAsync(newReservation.CarId); 
                var user = await _context.Users.FindAsync(userId); 
                if(car == null || user == null) return BadRequest("Car or user not found");
                var reservation = new Reservation
                {
                    UserId = userId,
                    CarId = newReservation.CarId,
                    StartDate = newReservation.StartDate,
                    EndDate = newReservation.EndDate,
                    Car = car,
                    User = user
                };
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();

                return Ok(reservation);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [Authorize]
        [HttpDelete("delete{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; 
                if(string.IsNullOrEmpty(userIdClaim)){
                    return BadRequest("User not authorized"); 
                }
                var userId = Int32.Parse(userIdClaim); 

                var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id && r.UserId == userId); 
                if(reservation == null){
                    return BadRequest("Reservation not found"); 
                }   
                _context.Reservations.Remove(reservation); 
                await _context.SaveChangesAsync(); 

                return Ok();
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

    }
}