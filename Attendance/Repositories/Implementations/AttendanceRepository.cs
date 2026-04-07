using Attendance.Models;
using Attendance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SchoolContext context;

        public AttendanceRepository(SchoolContext _context)
        {
            context = _context;
        }

        public List<AttendanceM> GetAll(int? studentId, int? subjectId)
        {


            var res = context.Attendances.Include(x => x.Student).Include(a => a.Subject)
                .Where(a => (studentId != null ? a.StudentId == studentId : true)
                && (subjectId != null ? a.SubjectId == subjectId : true)).ToList();
            return res;



            //var data = context.Attendances
            //    .Include(a => a.Student)
            //    .Include(a => a.Subject)
            //    .AsQueryable();

            //if (studentId != null)
            //    data = data.Where(a => a.StudentId == studentId);

            //if (subjectId != null)
            //    data = data.Where(a => a.SubjectId == subjectId);

            //return data.ToList();
        }

        public AttendanceM GetById(int id)
            => context.Attendances.Find(id);

        public void Add(AttendanceM att)
        {
            context.Attendances.Add(att);
            context.SaveChanges();
        }

        public void Update(AttendanceM att)
        {
            context.Attendances.Update(att);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var att = context.Attendances.Find(id);
            context.Attendances.Remove(att);
            context.SaveChanges();
        }
    }
}
