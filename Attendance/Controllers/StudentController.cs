using Attendance.Models;
using Attendance.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository _repo)
        {
            repo = _repo;
        }

        public IActionResult Index()
        {
            var students = repo.GetAll();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var student = repo.GetById(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            repo.Add(student);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            repo.Update(student);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
