using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisterationDate { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        public Student ?Student { get; set; }
        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course ?Course { get; set; }
    }
}
