using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class IsTeacherAvailableQuery : IRequest<Response<bool?>>
    {
        public int TeacherId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }
        public IsTeacherAvailableQuery(int teacherId, sbyte day, sbyte session)
        {
            TeacherId = teacherId;
            Day = day;
            Session = session;
        }
    }
}
