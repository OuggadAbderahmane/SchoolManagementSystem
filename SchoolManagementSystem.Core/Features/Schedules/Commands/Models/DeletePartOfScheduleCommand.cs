using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Models
{
    public class DeletePartOfScheduleCommand : IRequest<Response<string>>
    {
        public int SectionId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }

        public DeletePartOfScheduleCommand(int sectionId, sbyte day, sbyte session)
        {
            SectionId = sectionId;
            Day = day;
            Session = session;
        }
    }
}
