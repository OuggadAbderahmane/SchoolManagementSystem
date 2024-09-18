using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models
{
    public class AddSubjectTeacherCommand : IRequest<Response<IdResponse>>
    {
        public required int SubjectId { get; set; }
        public required int TeacherId { get; set; }
    }
}
