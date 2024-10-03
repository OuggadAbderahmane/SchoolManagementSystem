using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Models
{
    public class DeleteScheduleBySectionIdCommand : IRequest<Response<string>>
    {
        public int SectionId { get; set; }

        public DeleteScheduleBySectionIdCommand(int sectionId)
        {
            SectionId = sectionId;
        }
    }
}
