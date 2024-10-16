using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllCars()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car newCar)
        {
            if (newCar == null)
            {
                return BadRequest("Car object is null");
            }

            _context.Cars.Add(newCar);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
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
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpGet("filter")]
        public IActionResult GetFilteredCars([FromQuery] CarFilter filter)
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

            var filteredCars = carsQuery.ToList();

            return Ok(filteredCars);
        }
    }
}