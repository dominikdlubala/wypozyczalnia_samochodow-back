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
using Swashbuckle.AspNetCore.Annotations;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all reservations.", Description = "Returns a list of all reservations ordered by their end date in descending order.")]
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
                    .OrderByDescending(r => r.EndDate)
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Nie udało się pobrać rezerwacji", error = e.Message });
            }
        }

        [Authorize]
        [HttpPost("user")]
        [SwaggerOperation(Summary = "Retrieve user-specific reservations.", Description = "Returns a list of reservations made by the currently authenticated user, including associated car details.")]
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
                    .Include(r => r.Car) 
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
                    .OrderByDescending(r => r.EndDate)
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
        [SwaggerOperation(Summary = "Add a new reservation.", Description = "Creates a new reservation for the authenticated user.")]
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
                
                if(car == null || user == null) 
                    return BadRequest("Car or user not found");

                var overlappingReservation = await _context.Reservations
                    .Where(r => r.CarId == newReservation.CarId &&
                                r.StartDate < newReservation.EndDate &&
                                r.EndDate > newReservation.StartDate)
                    .FirstOrDefaultAsync();

                if (overlappingReservation != null)
                {
                    return BadRequest("This car is already reserved during the selected period.");
                }

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
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a reservation.", Description = "Deletes a reservation by its ID.")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try {
                var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id); 
                if(reservation == null){
                    return BadRequest("Reservation not found"); 
                }   
                _context.Reservations.Remove(reservation); 
                await _context.SaveChangesAsync(); 

                return NoContent();
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

    }
}