using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Models
{
    public class UpdateSectionCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public string? SectionName { get; set; }
        public int? ClassId { get; set; }
    }
}
