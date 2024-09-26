using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models
{
    public class GetStudentEvaluationByInfoQuery : IRequest<Response<GetStudentEvaluationResponse>>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }

        public GetStudentEvaluationByInfoQuery()
        {

        }

        public GetStudentEvaluationByInfoQuery(int studentId, int subjectId, int semesterId, int yearId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            SemesterId = semesterId;
            YearId = yearId;
        }
    }
}
