using System.ComponentModel.DataAnnotations;
using Ecom.Models;

namespace Ecom.ViewModels
{
   

    public class CreateOrderVM
    {
        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerID { get; set; }

        public DateTime? OrderDate { get; set; }

        public List<Customer>? Customers { get; set; }

        public List<OrderProductVM>? Products { get; set; }
    }
}