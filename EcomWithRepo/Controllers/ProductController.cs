using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Data;
using Ecom.Models;
using Ecom.Repo.IRepo;
using Ecom.Repo;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        //private readonly AppDbContext _context;
        readonly IProductRepo repo;

        public ProductController(IProductRepo repo) // inject
        {
            this.repo = repo;
        }

        // INDEX: list all products
        public IActionResult Index() // controller - Irepo(repo) - context  
        {
            var products = repo.GetAll();
            return View(products);
        }

        // DETAILS: view single product
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var product = repo.GetById(id);

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

           repo.Add(product);
           repo.Save();
            return RedirectToAction(nameof(Index));
        }

        // EDIT: GET
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = repo.GetById(id);
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

           repo.Update(product);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }

        // DELETE: GET
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = repo.GetById(id);
            if (product == null) return NotFound();

            return View(product);
        }

  
        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = repo.GetById(id);
            if (product == null) return NotFound();

            repo.Delete(product);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}