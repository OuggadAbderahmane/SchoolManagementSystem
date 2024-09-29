using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models
{
    public class DeleteSubjectTeacherCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteSubjectTeacherCommand(int id)
        {
            Id = id;
        }
    }
}
