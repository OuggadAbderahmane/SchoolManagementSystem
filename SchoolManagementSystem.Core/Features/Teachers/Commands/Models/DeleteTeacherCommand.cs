using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class DeleteTeacherCommand : IRequest<Response<string>>
    {
        public DeleteTeacherCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
