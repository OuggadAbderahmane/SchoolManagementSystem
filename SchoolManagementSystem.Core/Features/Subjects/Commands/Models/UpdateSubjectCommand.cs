using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Models
{
    public class UpdateSubjectCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public string? SubjectName { get; set; }
        public int? ClassId { get; set; }
    }
}
