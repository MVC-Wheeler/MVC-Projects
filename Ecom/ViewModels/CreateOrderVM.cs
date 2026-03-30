using Ecom.Models;

namespace Ecom.ViewModels
{
    public class CreateOrderVM
    {
        public int CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Customer>  ?Customers  { get; set; }
        public List<Product>? Products { get; set; }

    }
}
