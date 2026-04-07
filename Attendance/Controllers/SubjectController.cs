using Attendance.Models;
using Attendance.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository repo;

        public SubjectController(ISubjectRepository _repo)
        {
            repo = _repo;
        }

        public IActionResult Index()
        {
            return View(repo.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            repo.Add(subject);
            return RedirectToAction("Index");
        }
    }
}
