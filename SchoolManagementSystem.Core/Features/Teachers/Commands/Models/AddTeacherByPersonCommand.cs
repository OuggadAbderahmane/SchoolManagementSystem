using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddTeacherByPersonCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public required decimal Salary { get; set; }
        public required bool PermanentWork { get; set; }
    }
}
