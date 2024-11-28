using System.Net;
using System.Security.Claims;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
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
            var a = User.Identity;
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
        public async Task<IActionResult> GetUserReservationsById()
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
                    .Where(r => r.UserId == userId)
                    .ToListAsync();

                if (!reservations.Any())
                {
                    return NotFound("No reservations found for the user.");
                }

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
                    return BadRequest("Car object is null");
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
                    Car = car,
                    CarId = newReservation.CarId,
                    UserId = userId,
                    User = user,
                    StartDate = newReservation.StartDate,
                    EndDate = newReservation.EndDate
                };
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();

                return Ok(newReservation);
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