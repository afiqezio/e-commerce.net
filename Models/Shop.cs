using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{
    public class Shop
    {
        [Key]
        public Guid ShopID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Longitude { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
