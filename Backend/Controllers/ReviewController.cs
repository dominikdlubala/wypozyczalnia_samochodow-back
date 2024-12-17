using System.Security.Claims;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Review;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("car/{carId}")]
		public async Task<IActionResult> GetCarsReviews(int carId)
		{
			try
			{
				var carsReviews = await _context.Reviews
					.Where(r => r.CarId == carId)
					.Select(r => new ReviewDTO
                    {
                        Id = r.Id,
                        CarId = r.CarId,
                        UserId = r.UserId,
                        Username = r.User != null ? r.User.Username : "Unknown",
                        StarsOutOfFive = r.StarsOutOfFive,
                        ReviewContent = r.ReviewContent,
                        DateOfIssue = r.DateOfIssue
                    })
					.ToListAsync();

				return Ok(carsReviews);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = "Nie udało się pobrać recenzji samochodu: " + carId, error = ex.Message });
			}
		}


		[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCarsReview([FromBody] AddReviewDTO addReviewDTO){
            try {
                if (addReviewDTO == null)
                {
                    return BadRequest("Reservation object is null");
                }

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; 
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return BadRequest("User ID not found.");
                }
                var userId = Int32.Parse(userIdClaim); 
                var car = await _context.Cars.FindAsync(addReviewDTO.CarId); 
                var user = await _context.Users.FindAsync(userId); 
                if(car == null || user == null) return BadRequest("Car or user not found");
                var review = new Review
                {
                    UserId = userId,
                    CarId = addReviewDTO.CarId,
                    StarsOutOfFive = addReviewDTO.StarsOutOfFive,
                    ReviewContent = addReviewDTO.ReviewContent,
                    DateOfIssue = addReviewDTO.DateOfIssue,
                    Car = car,
                    User = user
                };
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();

                return Ok(review);
            }catch (Exception ex) {
                return BadRequest(new { message = "Nie udało się dodać recenzji samochodu ", error = ex.Message }); 

            }
        }
    }
}
