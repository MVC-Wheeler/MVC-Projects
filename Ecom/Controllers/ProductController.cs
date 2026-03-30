using Ecom.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext dbContext;

        public ProductController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {

            var products = dbContext.Products.ToList();
            return View(products);
        }
    }
}
