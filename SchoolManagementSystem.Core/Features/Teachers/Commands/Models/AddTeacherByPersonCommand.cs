using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddTeacherByPersonCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public bool PermanentWork { get; set; }
    }
}
