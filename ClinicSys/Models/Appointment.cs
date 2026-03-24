using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicSys.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Notes { get; set; }


        public Doctor ?Doctor { get; set; }
        [ForeignKey("Doctor")]
        public int ?DoctorId { get; set; }

        public Patient ?Patient { get; set; }
        [ForeignKey("Patient")]
        public int? PatientId { get; set;}
    }
}
