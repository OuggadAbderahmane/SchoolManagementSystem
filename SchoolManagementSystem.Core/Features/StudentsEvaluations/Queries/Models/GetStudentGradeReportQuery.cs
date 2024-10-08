using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models
{
    public class GetStudentGradeReportQuery : IRequest<Response<List<GetGradeReport>>>
    {
        public int YearId { get; set; }
        public int SemesterId { get; set; }

        public GetStudentGradeReportQuery(int yearId, int? semesterId)
        {
            YearId = yearId;
            SemesterId = semesterId == null ? 0 : (int)semesterId;
        }

    }
}
