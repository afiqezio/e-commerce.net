using System.ComponentModel.DataAnnotations;

namespace FlutterAPI.Models
{
    public class Shop
    {
        [Key]
        public Guid ShopID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
