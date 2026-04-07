using WebApplication1.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo
{
    public class StudentRepo : IStudentRepo
    {
        readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Student s)
        {
           _context.students.Add(s);
        }

        public void Delete(Student s)
        {
            _context.students.Remove(s);
        }

        public List<Student> GetAll()
        {
            return _context.students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.students.FirstOrDefault(s => s.StudentId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student s)
        {
            _context.students.Update(s);
        }
    }
}
