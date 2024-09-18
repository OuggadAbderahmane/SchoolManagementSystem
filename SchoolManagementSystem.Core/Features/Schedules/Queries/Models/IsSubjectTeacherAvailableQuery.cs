using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class IsSubjectTeacherAvailableQuery : IRequest<Response<bool?>>
    {
        public int SubjectTeacherId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }
        public IsSubjectTeacherAvailableQuery(int subjectTeacherId, sbyte day, sbyte session)
        {
            SubjectTeacherId = subjectTeacherId;
            Day = day;
            Session = session;
        }
    }
}
