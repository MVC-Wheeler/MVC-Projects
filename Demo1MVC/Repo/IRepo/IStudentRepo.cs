using WebApplication1.Models;

namespace WebApplication1.Repo.IRepo
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Delete(Student s);
        void Update(Student s);
        void Add(Student s);
        void Save();
    }
}
