using Attendance.Models;
using Attendance.Repositories.Interfaces;
using Attendance.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository repo;
        private readonly IStudentRepository studentRepo;
        private readonly ISubjectRepository subjectRepo;

        public AttendanceController(
            IAttendanceRepository _repo,
            IStudentRepository _studentRepo,
            ISubjectRepository _subjectRepo)
        {
            repo = _repo;
            studentRepo = _studentRepo;
            subjectRepo = _subjectRepo;
        }

        public IActionResult Index(int? studentId, int? subjectId)
        {
            var vm = new AttendanceVM
            {
                Attendances = repo.GetAll(studentId, subjectId),
                Students = studentRepo.GetAll(),
                Subjects = subjectRepo.GetAll(),
                StudentId = studentId ?? 0,
                SubjectId = subjectId ?? 0
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            var vm = new AttendanceVM
            {
                Students = studentRepo.GetAll(),
                Subjects = subjectRepo.GetAll(),
                Date = DateTime.Now
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AttendanceVM vm)
        {
            var att = new AttendanceM
            {
                StudentId = vm.StudentId,
                SubjectId = vm.SubjectId,
                Date = vm.Date,
                Status = vm.Status
            };

            repo.Add(att);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var att = repo.GetById(id);

            var vm = new AttendanceVM
            {
                AttendanceId = att.AttendanceMId,
                StudentId = att.StudentId,
                SubjectId = att.SubjectId,
                Date = att.Date,
                Status = att.Status,
                Students = studentRepo.GetAll(),
                Subjects = subjectRepo.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(AttendanceVM vm)
        {
            var att = new AttendanceM
            {
                AttendanceMId = vm.AttendanceId,
                StudentId = vm.StudentId,
                SubjectId = vm.SubjectId,
                Date = vm.Date,
                Status = vm.Status
            };

            repo.Update(att);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }


}
