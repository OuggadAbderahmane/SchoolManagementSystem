using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Models
{
    public class AddPartOfScheduleCommand : IRequest<Response<string>>
    {
        public int SectionId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }
        public int SubjectTeacherId { get; set; }
    }
}
