using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ?Description { get; set; }
        public int StockQuantity { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
