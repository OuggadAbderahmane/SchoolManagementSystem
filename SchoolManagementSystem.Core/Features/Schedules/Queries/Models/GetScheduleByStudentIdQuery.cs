using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleByStudentIdQuery : IRequest<Response<List<GetPartsOfStudentScheduleResponse>>>
    {
        public int StudentId { get; set; }
        public GetScheduleByStudentIdQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
