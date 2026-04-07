using WebApplication1.Models;

namespace WebApplication1.Repo.IRepo
{
    public interface IEnrollmentRepo
    {
        List<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Delete(Enrollment s);
        void Update(Enrollment s);
        void Add(Enrollment s);
        void Save();
    }
}
