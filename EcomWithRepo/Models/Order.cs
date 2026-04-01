using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer ?Customer { get; set; } 
        public List<OrderItem> ?OrderItems { get; set; } 

    }
}
