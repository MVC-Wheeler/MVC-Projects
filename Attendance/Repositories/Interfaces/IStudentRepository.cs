using Attendance.Models;

namespace Attendance.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
