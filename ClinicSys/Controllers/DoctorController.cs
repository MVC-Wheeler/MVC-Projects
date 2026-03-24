using ClinicSys.Models;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace ClinicSys.Controllers
{
    public class DoctorController : Controller
    {
        ClinicContext db = new ClinicContext()
            ;
      
        public IActionResult Index()
        {
            var docs= db.Doctors.ToList();

            return View(docs);
        }
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
           return RedirectToAction("Index");
        }

    }
}
