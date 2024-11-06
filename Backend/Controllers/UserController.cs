using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase {
    private readonly AppDbContext _context; 
    private readonly IConfiguration _configuration; 

    public UserController(AppDbContext context, IConfiguration configuration) {
        _context = context;
        _configuration = configuration; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
        return await _context.Users.ToListAsync(); 
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id) {
        var user = await _context.Users.FindAsync(id); 

        if(user == null) return NotFound(); 
        return user; 
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto credentials) {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == credentials.Username && u.Password == credentials.Password); 
        if(user == null) return Unauthorized("Invalid username or password"); 

        var tokenHandler = new JwtSecurityTokenHandler(); 

        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]); 
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        }; 

        var token = tokenHandler.CreateToken(tokenDescriptor); 
        var tokenString = tokenHandler.WriteToken(token); 

        return Ok(new { Token = tokenString }); 
    }

    [HttpPost("find")]
    public async Task<ActionResult<User>> FindUser([FromBody]LoginRequestDto credentials) {

        try {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == credentials.Username && user.Password == credentials.Password); 

            if(user == null) return NotFound(); 

            return user; 
        } catch (Exception e) {
            return BadRequest(e.Message); 
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> AddUser([FromBody] RegisterFormValues formValues) {

        if(!ModelState.IsValid) {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage); 
            foreach(var error in errors) {
                Console.WriteLine(error); 
            }
            return BadRequest(ModelState); 
        }

        User user = new User {
            Email = formValues.Email,
            Username = formValues.Username,
            Password = formValues.Password,
        };

        _context.Users.Add(user); 
        await _context.SaveChangesAsync(); 

        return Ok(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}