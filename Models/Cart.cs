using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{

    public class Cart
    {
        [Key]
        public Guid CartID { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }

}
