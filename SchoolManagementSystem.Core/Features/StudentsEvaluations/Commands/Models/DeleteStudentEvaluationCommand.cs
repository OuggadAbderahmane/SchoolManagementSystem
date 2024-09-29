using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models
{
    public class DeleteStudentEvaluationCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentEvaluationCommand(int id)
        {
            Id = id;
        }
    }
}
