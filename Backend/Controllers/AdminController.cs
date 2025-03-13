using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // User actions
        [HttpGet("user")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return Ok(await _context.Users.OrderByDescending(u => u.RegistrationDate).ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{id:int}")]
        [SwaggerOperation(Summary = "Retrieve a user by ID.", Description = "Returns a user object based on the provided ID.")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null) return NotFound();
                return user;
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null) return NotFound();

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Car Actions

        [SwaggerOperation(Summary = "Adds a car", Description = "Adds a Car type entity to database based on user input sent through an api request in a JSON body")]
        [HttpPost("car")]
        public async Task<IActionResult> AddCar([FromBody] AddOrEditCarDTO carDto)
        {
            var car = new Car
            {
                Brand = carDto.Brand,
                Model = carDto.Model,
                ImageUrl = carDto.ImageUrl,
                FuelType = carDto.FuelType,
                Capacity = carDto.Capacity,
                BodyType = carDto.BodyType,
                Color = carDto.Color,
                PricePerDay = carDto.PricePerDay,
                ProductionYear = carDto.ProductionYear
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddCar), new { id = car.Id }, car);
        }

        [SwaggerOperation(Summary = "Updates a car", Description = "Updates car of a provided id, based on the JSON body sent in an api request")]
        [HttpPut("car/{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] AddOrEditCarDTO carDto)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            car.Brand = carDto.Brand;
            car.Model = carDto.Model;
            car.ImageUrl = carDto.ImageUrl;
            car.FuelType = carDto.FuelType;
            car.Capacity = carDto.Capacity;
            car.BodyType = carDto.BodyType;
            car.Color = carDto.Color;
            car.PricePerDay = carDto.PricePerDay;
            car.ProductionYear = carDto.ProductionYear;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [SwaggerOperation(Summary = "Deletes a car", Description = "Removes a car of a provided id from the database")]
        [HttpDelete("car/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                var car = _context.Cars.Find(id);

                if (car == null)
                {
                    return NotFound();
                }

                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [SwaggerOperation(Summary = "Uploads a car image", Description = "Uploads a car image to the database")]
        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadCarImage(IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                {
                    return BadRequest("No image file provided.");
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".jfif", ".xbm", ".tiff", ".pjp", ".apng", ".svgz", ".ico", ".tiff", ".svg", ".webp", ".bmp", ".pjpeg", ".avif"};
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file type.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "cars");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                return Ok(new { uniqueFileName });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [SwaggerOperation(Summary = "Retrieves a car image", Description = "Returns an image file from the database based on the provided car id")]
        [HttpGet("images/{carId}")]
        public async Task<IActionResult> GetCarImage(int carId)
        {
            try
            {
                var car = await _context.Cars.FindAsync(carId);
                if (car == null || string.IsNullOrEmpty(car.ImageUrl))
                {
                    return NotFound($"Image for car with ID {carId} not found.");
                }

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", car.ImageUrl.TrimStart('/'));
                if (!System.IO.File.Exists(imagePath))
                {
                    return NotFound("Image file not found on server.");
                }

                var fileExtension = Path.GetExtension(imagePath).ToLower();
                string mimeType = "image/jpeg";
                if (fileExtension == ".png")
                {
                    mimeType = "image/png";
                }
                else if (fileExtension == ".gif")
                {
                    mimeType = "image/gif";
                }

                var imageFile = System.IO.File.OpenRead(imagePath);
                return File(imageFile, mimeType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
