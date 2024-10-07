using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Models
{
    public class AddPartOfScheduleCommand : IRequest<Response<string>>
    {
        public required int SectionId { get; set; }
        public required sbyte Day { get; set; }
        public required sbyte Session { get; set; }
        public required int SubjectTeacherId { get; set; }
    }
}
