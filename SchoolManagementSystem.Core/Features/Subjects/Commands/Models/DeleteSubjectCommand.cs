using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteSubjectCommand(int id)
        {
            Id = id;
        }
    }
}
