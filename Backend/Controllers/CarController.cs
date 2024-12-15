using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Car;
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
            try {
                var cars =  await _context.Cars.OrderByDescending(c => c.Id).ToListAsync();
                return Ok(cars);
            } catch (Exception e) {
                return BadRequest(e); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            try {
                var car = await _context.Cars.Include(c => c.Reservations).FirstOrDefaultAsync(c => c.Id == id);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(car);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpGet("topCars")]
        public async Task<IActionResult> GetTopCars() {
            try {
                var cars = await _context.Cars
                    .Select(c => new {
                        c.Id, 
                        c.Brand, 
                        c.Model, 
                        c.ImageUrl, 
                        c.FuelType, 
                        c.Capacity, 
                        c.BodyType, 
                        c.Color, 
                        c.PricePerDay,
                        c.ProductionYear,
                        ReservationCount = _context.Reservations.Count(r => r.CarId == c.Id)
                    })
                    .OrderByDescending(c => c.ReservationCount)
                    .Take(3)
                    .ToListAsync(); 
                return Ok(cars); 
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpGet("uniqueProperties")]
        public async Task<IActionResult> GetUniquePropertyValues()
        {
            try {
                var uniqueValues = new UniqueCarPropertyValues
                {
                    FuelTypes = await _context.Cars
                                    .Select(c => c.FuelType)
                                    .Distinct()
                                    .ToListAsync(),

                    BodyTypes = await _context.Cars
                                    .Select(c => c.BodyType)
                                    .Distinct()
                                    .ToListAsync(),

                    Colors = await _context.Cars
                                    .Select(c => c.Color)
                                    .Distinct()
                                    .ToListAsync(),
                };

                return Ok(uniqueValues);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredCars([FromQuery] CarFilter filter)
        {
            try {
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

                // Daty w formacie ISO 8601 (yyyy-MM-ddTHH:mm:ss)
                // Przykładowo 2024-10-25T12:00:00
                if (filter.ReservationStart != null && filter.ReservationEnd!= null)
                {
                    DateTime startReservation = filter.ReservationStart.Value;
                    DateTime endReservation = filter.ReservationEnd.Value;

                    carsQuery = carsQuery.Where(c => 
                        c.Reservations == null || 
                        !c.Reservations.Any(r => 
                            (r.StartDate >= startReservation && r.StartDate < endReservation) || // Inna rezerwacja nie zaczyna się pomiędzy
                            (r.EndDate > startReservation && r.EndDate <= endReservation)        // Inna rezerwacja nie kończy się pomiędzy
                        )
                    );
                }

                var filteredCars = await carsQuery.ToListAsync();

                return Ok(filteredCars);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }
    }
}