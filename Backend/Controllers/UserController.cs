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
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User") // Dodanie flagi do tokena
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("User not found");
        }

        // Aktualizacja w³aœciwoœci u¿ytkownika
        user.Username = updateUserDto.Username ?? user.Username;
        user.Email = updateUserDto.Email ?? user.Email;
        user.FirstName = updateUserDto.FirstName ?? user.FirstName;
        user.LastName = updateUserDto.LastName ?? user.LastName;

        // Dodaj inne w³aœciwoœci do aktualizacji w razie potrzeby

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest($"Error updating user: {ex.Message}");
        }

        return Ok(user); // Zwraca zaktualizowanego u¿ytkownika
    }

    [HttpPut("{id}/change-password")]
    //[Authorize] // U¿ywamy autoryzacji, aby upewniæ siê, ¿e u¿ytkownik jest zalogowany
    // Z jakiegos powodu jak by³o [Authorize] to nie dzia³a³o
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDTO changePasswordDto)
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString();
        Console.WriteLine("Token: " + token); // Sprawdzanie tokena

        // Sprawdzenie, czy dane s¹ poprawne
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Znalezienie u¿ytkownika w bazie danych
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound("User not found");
        }

        // Sprawdzanie, czy aktualne has³o jest poprawne
        if (user.Password != changePasswordDto.CurrentPassword)
        {
            return Unauthorized("Aktualne has³o jest niepoprawne");
        }

        // Zmiana has³a
        user.Password = changePasswordDto.NewPassword;

        // Zapisanie nowego has³a w bazie danych
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest($"Error updating password: {ex.Message}");
        }

        return Ok("Has³o zosta³o zmienione");
    }
}