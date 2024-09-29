using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Models
{
    public class DeleteSectionCommand : IRequest<Response<string>>
    {
        public DeleteSectionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
