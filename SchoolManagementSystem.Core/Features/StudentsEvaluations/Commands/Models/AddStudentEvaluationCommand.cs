using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models
{
    public class AddStudentEvaluationCommand : IRequest<Response<IdResponse>>
    {
        public required int StudentId { get; set; }
        public required int SubjectId { get; set; }
        public required int SemesterId { get; set; }
        public required int YearId { get; set; }
        public double? ContinuousAssessment { get; set; }
        public double? FirstTest { get; set; }
        public double? SecondTest { get; set; }
        public double? Exam { get; set; }
    }
}
