using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class RegisterEnrollmentViewModel
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public int StudentId { get;set; }
        public int CourseId { get;set; }

        public DateTime RegistrationDate {  get; set; }
    }
}
