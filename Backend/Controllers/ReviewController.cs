using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _context.Reviews
                    .Include(r => r.User)
                    .Include(r => r.Car)
                    .Select(r => new
                    {
                        r.Id,
                        r.CarId,
                        CarName = $"{r.Car.Brand} {r.Car.Model}",
                        r.UserId,
                        UserName = r.User.Username,
                        r.StarsOutOfFive,
                        r.ReviewContent,
                        r.DateOfIssue
                    })
                    .ToListAsync();

                return Ok(reviews);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Nie udało się pobrać recenzji", error = e.Message });
            }
        }
    }
}
