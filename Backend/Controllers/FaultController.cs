using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
