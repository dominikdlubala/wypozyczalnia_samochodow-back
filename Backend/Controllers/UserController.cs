using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Backend.Models.DTOs.User;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase {
    private readonly AppDbContext _context; 
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public UserController(AppDbContext context, IConfiguration configuration) {
        _context = context;
        _configuration = configuration; 
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != id) return Forbid();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto credentials)
    {
        try
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == credentials.Username);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, credentials.Password) == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid username or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtSettings:Audience"],
                Issuer = _configuration["JwtSettings:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterFormValues formValues)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _context.Users.AnyAsync(u => u.Username == formValues.Username || u.Email == formValues.Email))
                return BadRequest("Username or Email already exists");

            var user = new User
            {
                Email = formValues.Email,
                Username = formValues.Username,
                Password = _passwordHasher.HashPassword(null, formValues.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDto)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != id && !User.IsInRole("Admin")) return Forbid();

            if (await _context.Users.AnyAsync(u => u.Id != userId && (u.Username == updateUserDto.Username || u.Email == updateUserDto.Email)))
                return BadRequest("Username or Email already exists");

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.Username = updateUserDto.Username ?? user.Username;
            user.Email = updateUserDto.Email ?? user.Email;
            user.FirstName = updateUserDto.FirstName ?? user.FirstName;
            user.LastName = updateUserDto.LastName ?? user.LastName;

            await _context.SaveChangesAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}/change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDTO changePasswordDto)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != id) return Forbid();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, changePasswordDto.CurrentPassword) == PasswordVerificationResult.Failed)
                return Unauthorized("Current password is incorrect");

            user.Password = _passwordHasher.HashPassword(user, changePasswordDto.NewPassword);
            await _context.SaveChangesAsync();
            return Ok("Password changed successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}