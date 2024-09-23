using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models
{
    public class GetGradeReportQuery : IRequest<Response<List<GetGradeReport>>>
    {
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int SemesterId { get; set; }

        public GetGradeReportQuery(int studentId, int yearId, int? semesterId)
        {
            StudentId = studentId;
            YearId = yearId;
            SemesterId = semesterId == null ? 0 : (int)semesterId;
        }

    }
}
