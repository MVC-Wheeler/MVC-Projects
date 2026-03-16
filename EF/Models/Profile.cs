using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW3.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
