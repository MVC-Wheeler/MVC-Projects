using Attendance.Models;

namespace Attendance.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAll();
        void Add(Subject subject);
    }
}
