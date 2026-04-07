using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        readonly AppDbContext _context;
        public EnrollmentRepo(AppDbContext _context)
        {
           this._context = _context; 
        }
        public void Add(Enrollment s)
        {
            _context.enrollments.Add(s);
        }

        public void Delete(Enrollment s)
        {
            _context.enrollments.Remove(s);
        }

        public List<Enrollment> GetAll()
        {
            
           var included = _context.enrollments.Include(c=>c.Student ).Include(c=>c.Course).ToList();
         
            return included;
        }

        public Enrollment GetById(int id)
        {
            return _context.enrollments.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Enrollment s)
        {
            _context.enrollments.Update(s);
        }
    }
}
