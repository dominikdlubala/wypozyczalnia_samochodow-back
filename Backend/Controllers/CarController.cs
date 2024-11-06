﻿using System.Net;
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
            try {
                var cars =  await _context.Cars.ToListAsync();
                return Ok(cars);
            } catch (Exception e) {
                return BadRequest(e); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            try {
                var car = await _context.Cars.FindAsync(id);

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
                    .Take(5)
                    .ToListAsync(); 
                return Ok(cars); 
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car newCar)
        {
            try {
                if (newCar == null)
                {
                    return BadRequest("Car object is null");
                }
                await _context.Cars.AddAsync(newCar);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            try {
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
            } catch (Exception e){
                return BadRequest(e); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try {
                var car = _context.Cars.Find(id);

                if (car == null)
                {
                    return NotFound();
                }

                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();

                return NoContent();
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

        [HttpPost("{id}/uploadImage")]
        public async Task<IActionResult> UploadCarImage(int id, IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                {
                    return BadRequest("No image file provided.");
                }

                var car = await _context.Cars.FindAsync(id);
                if (car == null)
                {
                    return NotFound("Car not found.");
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file type.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder); 

                var uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                car.ImageUrl = $"/uploads/{uniqueFileName}";
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();

                return Ok(new { ImageUrl = car.ImageUrl });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("images/{id}")]
        public async Task<IActionResult> GetCarImage(int id)
        {
            try
            {
                var car = await _context.Cars.FindAsync(id);
                if (car == null || string.IsNullOrEmpty(car.ImageUrl))
                {
                    return NotFound($"Image for car with ID {id} not found.");
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