using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaultController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FaultController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFaults()
        {
            try
            {
                var faults = await _context.Faults
                    .Include(f => f.Car)
                    .Include(f => f.ReportedUser)
                    .Select(f => new
                    {
                        f.Id,
                        f.CarId,
                        CarName = $"{f.Car.Brand} {f.Car.Model}",
                        f.ReportedUserId,
                        ReportedUserName = $"{f.ReportedUser.FirstName} {f.ReportedUser.LastName}",
                        f.Description,
                        f.DateOfIssue
                    })
                    .ToListAsync();

                return Ok(faults);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Failed to fetch faults", error = e.Message });
            }
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetUserFaults()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return BadRequest("User ID not found.");
                }

                int userId = Int32.Parse(userIdClaim);

                var faults = await _context.Faults
                    .Include(f => f.Car)
                    .Where(f => f.ReportedUserId == userId)
                    .Select(f => new
                    {
                        f.Id,
                        f.CarId,
                        CarName = $"{f.Car.Brand} {f.Car.Model}",
                        f.Description,
                        f.DateOfIssue
                    })
                    .ToListAsync();

                return Ok(faults);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Failed to fetch user's faults", error = e.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFault([FromBody] Fault newFault)
        {
            try
            {
                if (newFault == null)
                {
                    return BadRequest("Fault object is null");
                }

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return BadRequest("User ID not found.");
                }

                var userId = Int32.Parse(userIdClaim);

                var car = await _context.Cars.FindAsync(newFault.CarId);
                if (car == null)
                {
                    return BadRequest("Car not found.");
                }

                var fault = new Fault
                {
                    CarId = newFault.CarId,
                    ReportedUserId = userId,
                    Description = newFault.Description,
                    DateOfIssue = DateTime.UtcNow,
                    Car = car,
                    ReportedUser = await _context.Users.FindAsync(userId)
                };

                await _context.Faults.AddAsync(fault);
                await _context.SaveChangesAsync();

                return Ok(fault);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Failed to add fault", error = e.Message });
            }
        }
    }
}
