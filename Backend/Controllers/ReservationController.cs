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
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            try {
                var reservations =  await _context.Reservations.ToListAsync();
                return Ok(reservations);
            } catch (Exception e) {
                return BadRequest(e); 
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
        public async Task<IActionResult> AddReservation([FromBody] Reservation newReservation)
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
                newReservation.Car = car; 
                newReservation.User = user; 
                await _context.Reservations.AddAsync(newReservation);
                await _context.SaveChangesAsync();

                return Ok(newReservation);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }


        [HttpDelete("delete{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try {
                var car = _context.Cars.Find(id);

                if (car == null)
                {
                    return NotFound();
                }

                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();

                return NoContent();
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

    }
}