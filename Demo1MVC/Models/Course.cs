using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        
        public int CourseId { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [Range(1, 6)]
        public int Credits { get; set; }
        public List<Enrollment>? Enrollments { get; set; }
    }
}
