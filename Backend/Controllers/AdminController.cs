using Backend.Data;
using Backend.Models;
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
        [HttpPost("cars")]
        public async Task<IActionResult> AddCar([FromBody] Car newCar)
        {
            try
            {
                if (newCar == null)
                {
                    return BadRequest("Car object is null");
                }
                await _context.Cars.AddAsync(newCar);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddCar", new { id = newCar.Id }, newCar);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("cars/{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("cars/{id}")]
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
    }

}
