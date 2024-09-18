using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class IsSessionAvailableQuery : IRequest<Response<bool?>>
    {
        public int SectionId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }
        public IsSessionAvailableQuery(int sectionId, sbyte day, sbyte session)
        {
            SectionId = sectionId;
            Day = day;
            Session = session;
        }
    }
}
