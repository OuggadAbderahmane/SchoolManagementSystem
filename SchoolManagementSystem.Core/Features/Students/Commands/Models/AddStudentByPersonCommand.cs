using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentByPersonCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public int? SectionId { get; set; }
        public int? GuardianId { get; set; }
        public required bool IsAvtive { get; set; }
    }
}
