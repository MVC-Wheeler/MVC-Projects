using WebApplication1.Models;

namespace WebApplication1.Repo.IRepo
{
    public interface ICourseRepo
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Delete(Course s);
        void Update(Course s);
        void Add(Course s);
        void Save();
    }
}
