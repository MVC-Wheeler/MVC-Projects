using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Data;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // INDEX: list all products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // DETAILS: view single product
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var product = _context.Products
                .FirstOrDefault(p => p.ProductID == id);

            if (product == null) return NotFound();

            return View(product);
        }

        // CREATE: GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // EDIT: GET
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // EDIT: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductID) return BadRequest();

            if (!ModelState.IsValid)
                return View(product);

            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // DELETE: GET
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = _context.Products
                .FirstOrDefault(p => p.ProductID == id);
            if (product == null) return NotFound();

            return View(product);
        }

  
        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}