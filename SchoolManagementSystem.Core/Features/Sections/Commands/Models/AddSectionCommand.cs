using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Models
{
    public class AddSectionCommand : IRequest<Response<IdResponse>>
    {
        public required string SectionName { get; set; }
        public required int ClassId { get; set; }
    }
}
