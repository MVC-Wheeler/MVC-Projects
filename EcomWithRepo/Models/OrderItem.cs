using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Product ?Product { get; set; }
        public Order? Order { get; set; }
    }
}
