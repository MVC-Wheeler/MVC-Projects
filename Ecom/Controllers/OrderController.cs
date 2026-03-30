using Ecom.Data;
using Ecom.Models;
using Ecom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // =========================
        // GET: Create Order
        // =========================
        public IActionResult Create()
        {
            var vm = new CreateOrderVM
            {
                Customers = _context.Customers.ToList(),
                Products = _context.Products.ToList(),
                OrderDate = DateTime.Now
            };

            return View(vm);
        }

        // =========================
        // POST: Create Order
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOrderVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Customers = _context.Customers.ToList();
                vm.Products = _context.Products.ToList();
                return View(vm);
            }

            var order = new Order
            {
                CustomerID = vm.CustomerID,
                OrderDate = vm.OrderDate ?? DateTime.Now,
                TotalAmount = vm.TotalAmount
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }
    }
}