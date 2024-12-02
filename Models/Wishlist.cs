using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{

    public class Wishlist
    {
        [Key]
        public Guid WishlistID { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product? Product { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}
