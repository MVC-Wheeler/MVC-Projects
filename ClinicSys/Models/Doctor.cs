namespace ClinicSys.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Specialty { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
