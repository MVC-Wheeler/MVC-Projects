using Attendance.Models;
using Attendance.Repositories.Interfaces;

namespace Attendance.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolContext context;

        public SubjectRepository(SchoolContext _context)
        {
            context = _context;
        }

        public List<Subject> GetAll() => context.Subjects.ToList();

        public void Add(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }
    }
}
