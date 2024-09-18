using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.FinalExams.Queries.Models
{
    public class GetFinalExamByInfoQuery : IRequest<Response<GetFinalExamResponse>>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }

        public GetFinalExamByInfoQuery()
        {

        }

        public GetFinalExamByInfoQuery(int studentId, int subjectId, int semesterId, int yearId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            SemesterId = semesterId;
            YearId = yearId;
        }
    }
}
