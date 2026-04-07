using Attendance.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance
{


    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AttendanceM> Attendances { get; set; }
    }
}
