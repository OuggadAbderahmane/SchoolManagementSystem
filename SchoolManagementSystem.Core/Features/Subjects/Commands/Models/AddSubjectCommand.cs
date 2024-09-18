using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Models
{
    public class AddSubjectCommand : IRequest<Response<IdResponse>>
    {
        public required string SubjectName { get; set; }
        public required int ClassId { get; set; }
    }
}
