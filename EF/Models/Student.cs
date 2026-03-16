using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Range(15, 20)]
        public int Age { get; set; }
        public string Address { get; set; }

        public Profile Profile { get; set; }
        public int DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public List<Course> Courses { get; set; }
    }
}
