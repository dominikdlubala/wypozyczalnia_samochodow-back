using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars =  await _context.Cars.ToListAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car newCar)
        {
            if (newCar == null)
            {
                return BadRequest("Car object is null");
            }

            await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            var existingCar = _context.Cars.Find(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.Brand = updatedCar.Brand;
            existingCar.Model = updatedCar.Model;
            existingCar.ImageUrl = updatedCar.ImageUrl;
            existingCar.FuelType = updatedCar.FuelType;
            existingCar.Capacity = updatedCar.Capacity;
            existingCar.BodyType = updatedCar.BodyType;
            existingCar.Color = updatedCar.Color;
            existingCar.PricePerDay = updatedCar.PricePerDay;
            existingCar.ProductionYear = updatedCar.ProductionYear;

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
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


        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredCars([FromQuery] CarFilter filter)
        {
            var carsQuery = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(filter.EngineType))
            {
                carsQuery = carsQuery.Where(c => c.FuelType == filter.EngineType);
            }

            if (!string.IsNullOrEmpty(filter.Displacement))
            {
                if(filter.Displacement == "smallEngine")
                {
                    carsQuery = carsQuery.Where(c => c.Capacity >= 1 &&  c.Capacity <= 2);
                }
                if (filter.Displacement == "mediumEngine")
                {
                    carsQuery = carsQuery.Where(c => c.Capacity >= 2 && c.Capacity <= 3);
                }
                if (filter.Displacement == "bigEngine")
                {
                    carsQuery = carsQuery.Where(c => c.Capacity > 3);
                }
            }

            if (!string.IsNullOrEmpty(filter.BodyType))
            {
                carsQuery = carsQuery.Where(c => c.BodyType == filter.BodyType);
            }

            if (!string.IsNullOrEmpty(filter.Colour))
            {
                carsQuery = carsQuery.Where(c => c.Color == filter.Colour);
            }

            if (!string.IsNullOrEmpty(filter.PriceMin) && float.TryParse(filter.PriceMin, out var priceMin))
            {
                carsQuery = carsQuery.Where(c => c.PricePerDay >= priceMin);
            }

            if (!string.IsNullOrEmpty(filter.PriceMax) && float.TryParse(filter.PriceMax, out var priceMax))
            {
                carsQuery = carsQuery.Where(c => c.PricePerDay <= priceMax);
            }

            if (!string.IsNullOrEmpty(filter.YearMin) && int.TryParse(filter.YearMin, out var yearMin))
            {
                carsQuery = carsQuery.Where(c => c.ProductionYear >= yearMin);
            }

            if (!string.IsNullOrEmpty(filter.YearMax) && int.TryParse(filter.YearMax, out var yearMax))
            {
                carsQuery = carsQuery.Where(c => c.ProductionYear <= yearMax);
            }

            var filteredCars = await carsQuery.ToListAsync();

            return Ok(filteredCars);
        }
    }
}