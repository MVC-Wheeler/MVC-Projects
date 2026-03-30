using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
