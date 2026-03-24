using System.ComponentModel.DataAnnotations;

namespace ClinicSys.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ?Age { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
