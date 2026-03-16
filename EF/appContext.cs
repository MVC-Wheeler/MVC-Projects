using EFW3.Models;
using Microsoft.EntityFrameworkCore;

public class appContext : DbContext
{
    //public appContext(DbContextOptions<appContext> options) : base(options)
    //{
    //}

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }  

    public DbSet<Profile> Profiles { get; set; }

    // fluent api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().
            HasOne(s => s.Department)
            .WithMany(d => d.Students).HasForeignKey(s => s.DepartmentId);

        modelBuilder.Entity<Student>()
            .HasOne(s=>s.Profile)
            .WithOne(p=>p.Student)
            .HasForeignKey<Profile>(p=>p.StudentId);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
        //modelBuilder.Entity<Student>().HasKey(s => s.Id);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolW3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolW3;Trusted_Connection=True;");
    //}
}