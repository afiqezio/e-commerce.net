using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [ForeignKey(nameof(Shop))]
        public Guid ShopID { get; set; }
        public Shop? Shop { get; set; }
    }
}
