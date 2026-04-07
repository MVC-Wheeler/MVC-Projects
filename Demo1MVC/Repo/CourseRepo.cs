using WebApplication1.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo
{
    public class CourseRepo : ICourseRepo
    {
        readonly AppDbContext _context;
        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Course s)
        {
            _context.courses.Add(s);
        }

        public void Delete(Course s)
        {
            _context.courses.Remove(s);
        }

        public List<Course> GetAll()
        {
           return _context.courses.ToList();
        }

        public Course GetById(int id)
        {
           return _context.courses.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Course s)
        {
            _context.courses.Update(s);
        }
    }
}
