using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolMVC.Models;

namespace SchoolMVC.Controllers
{
    public class StudentController : Controller
    {
        appContext db= new appContext();
        public IActionResult Index()
        {
            var stu = db.Students.ToList();

            return Ok(stu);

            //return View();
        }

        public IActionResult getAll() //with eager loading
        {
            var stu = db.Students.Include(s=>s.Department).ToList();

            return Ok(stu);

            //return View();
        }
        public IActionResult getAllExplicit()//with explicit loading
        {
            var stu = db.Students.First();
            db.Entry(stu).Reference(s=>s.Department).Load();

            return Ok(stu);

            //return View();
        }


    }
}
