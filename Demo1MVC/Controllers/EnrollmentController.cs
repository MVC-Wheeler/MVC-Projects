using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo.IRepo;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EnrollmentController : Controller
    {
        readonly IEnrollmentRepo _repo;
        readonly IStudentRepo _studentRepo;
        readonly ICourseRepo _courseRepo;

        public EnrollmentController(IEnrollmentRepo repo,IStudentRepo studentRepo, ICourseRepo courseRepo)
        {
            _repo = repo;

            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            var enrollments = _repo.GetAll();
            return View(enrollments);
        }
        public IActionResult Regsiter()
        {
            var enrollmentVm = new RegisterEnrollmentViewModel()
            {
                Students = _studentRepo.GetAll(),
                Courses = _courseRepo.GetAll(),
                RegistrationDate = DateTime.Now,
            };
            return View(enrollmentVm);
        }
        [HttpPost]
        public IActionResult Regsiter(RegisterEnrollmentViewModel vm)
        {
            var enrollment = new Enrollment()
            {
                StudentID = vm.StudentId,
                CourseID = vm.CourseId,
                RegisterationDate = vm.RegistrationDate,
            };

            _repo.Add(enrollment);
            _repo.Save();

            return RedirectToAction("Index");
        }
    }
}
