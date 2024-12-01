using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlutterAPI.Data;
using FlutterAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly FlutterDbContext _context;

        public RegisterController(FlutterDbContext context)
        {
            _context = context;
        }

        // POST: api/Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            // Check if email already exists
            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
            {
                return BadRequest(new { Message = "Email is already registered." });
            }

            // Create a new user
            var newUser = new User
            {
                UserID = Guid.NewGuid(),
                FullName = userDto.FullName,
                Email = userDto.Email,
                Phone = userDto.Phone,
                PasswordHash = HashPassword(userDto.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save the user to the database
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully." });
        }

        // Utility to hash passwords
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    // DTO to simplify the input
    public class UserRegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
