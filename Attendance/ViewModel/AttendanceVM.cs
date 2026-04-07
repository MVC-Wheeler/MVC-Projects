using Attendance.Models;

namespace Attendance.ViewModel
{

    public class AttendanceVM
    {
     
            public int AttendanceId { get; set; }
            public int StudentId { get; set; }
            public int SubjectId { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
            public List<Student> Students { get; set; }
            public List<Subject> Subjects { get; set; }
           public List<AttendanceM> Attendances { get; set; }

    }
}
