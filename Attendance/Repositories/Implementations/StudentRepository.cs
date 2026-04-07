using Attendance.Models;
using Attendance.Repositories.Interfaces;

namespace Attendance.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext _context)
        {
            context = _context;
        }

        public List<Student> GetAll() => context.Students.ToList();

        public Student GetById(int id) => context.Students.Find(id);

        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = context.Students.Find(id);
            context.Students.Remove(s);
            context.SaveChanges();
        }
    }
}
