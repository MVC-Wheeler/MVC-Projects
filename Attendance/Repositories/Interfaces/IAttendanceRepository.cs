using Attendance.Models;

namespace Attendance.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        List<AttendanceM> GetAll(int? studentId, int? subjectId);
        AttendanceM GetById(int id);
        void Add(AttendanceM attendance);
        void Update(AttendanceM attendance);
        void Delete(int id);
    }
}
