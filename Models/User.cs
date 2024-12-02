using System.ComponentModel.DataAnnotations;

namespace FlutterAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer; // Default role is Customer
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum UserRole
    {
        Admin = 0,
        Customer = 1
    }
}
