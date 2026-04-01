using System.ComponentModel.DataAnnotations;

namespace Ecom.ViewModels
{
    public class OrderProductVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be >= 0")]
        public int Quantity { get; set; }
    }
}
