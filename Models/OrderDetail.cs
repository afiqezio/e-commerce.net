using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{

    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailID { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderID { get; set; }

        public Order? Order { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }

        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }
    }

}
