using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<Enrollment>? Enrollments { get; set; }
    }
}
