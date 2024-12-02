using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{

    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        public User? User { get; set; }

    }

}
