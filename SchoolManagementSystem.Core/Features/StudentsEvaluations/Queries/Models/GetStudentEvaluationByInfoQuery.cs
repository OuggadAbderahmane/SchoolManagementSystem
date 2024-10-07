using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models
{
    public class GetStudentEvaluationByInfoQuery : IRequest<Response<GetStudentEvaluationResponse>>
    {
        public required int StudentId { get; set; }
        public required int SubjectId { get; set; }
        public required int SemesterId { get; set; }
        public required int YearId { get; set; }

    }
}
