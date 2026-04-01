using Ecom.Data;
using Ecom.Models;
using Ecom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)//x
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)//order-orderitem-product
                    .ThenInclude(oi => oi.Product)
                .ToList();

            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateOrderVM
            {
                Customers = _context.Customers.ToList(),
                Products = _context.Products.Select(p => new OrderProductVM
                {
                    ProductID = p.ProductID,
                    ProductName = p.Name,
                    Price = p.Price,
                    Quantity = 0 // default
                }).ToList(),
                OrderDate = DateTime.Now
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOrderVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Customers = _context.Customers.ToList();
                vm.Products = _context.Products.Select(p => new OrderProductVM
                {
                    ProductID = p.ProductID,
                    ProductName = p.Name,
                    Price = p.Price,
                    Quantity = 0
                }).ToList();
                return View(vm);
            }

            var order = new Order
            {
                CustomerID = vm.CustomerID,
                OrderDate = vm.OrderDate ?? DateTime.Now,
                TotalAmount = vm.Products.Where(p => p.Quantity > 0).Sum(p => p.Price * p.Quantity),
                OrderItems = vm.Products
                    .Where(p => p.Quantity > 0)
                    .Select(p => new OrderItem
                    {
                        ProductID = p.ProductID,
                        Quantity = p.Quantity,
                        UnitPrice = p.Price
                    }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}