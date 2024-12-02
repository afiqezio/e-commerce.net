using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
    }

}
