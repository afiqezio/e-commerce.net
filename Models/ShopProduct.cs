using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{
    public class ShopProduct
    {
        [Key]
        public Guid ShopProductID { get; set; }

        [ForeignKey(nameof(Shop))]
        public Guid ShopID { get; set; }

        public Shop? Shop { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; } 
    }

}
