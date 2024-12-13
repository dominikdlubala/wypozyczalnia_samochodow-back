using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // Akcje dotyczące klasy Car
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
