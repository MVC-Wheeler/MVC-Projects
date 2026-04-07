using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Student> students {  get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Student).WithMany(a => a.Enrollments).HasForeignKey(a => a.StudentID);
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Course).WithMany(a => a.Enrollments).HasForeignKey(a => a.CourseID);
        }

    }
}
