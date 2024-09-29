using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
