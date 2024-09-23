using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models
{
    public class UpdateStudentEvaluationCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public double? ContinuousAssessment { get; set; }
        public double? FirstTest { get; set; }
        public double? SecondTest { get; set; }
        public double? Exam { get; set; }
    }
}
