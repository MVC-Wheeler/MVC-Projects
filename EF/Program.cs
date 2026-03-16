using EFW3.Models;

namespace EFW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            appContext context= new appContext();
            Department department = new Department()
            {
                Name = "Test",
                
                
            };
            context.Departments.Add(department);
            context.SaveChanges();

            Student student = new Student()
            {
                Name = "student",
                DepartmentId = 1,
                Address="aaaa"

            };
            context.Students.Add(student);
            context.SaveChanges();

        }
    }
}
