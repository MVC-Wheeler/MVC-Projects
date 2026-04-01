using Ecom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class TestController : Controller
    {
        Itest t;
        Itest t2;
        public TestController(Itest t, Itest t2)
        {
            this.t = t;
            this.t2 = t2;
        }
        public IActionResult Index()
        {
            return Ok($"{t.add()}, {t2.add()}");
            //return View();
        }
    }
}
