using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleByTeacherIdQuery : IRequest<Response<List<GetPartsOfTeacherScheduleResponse>>>
    {
        public int TeacherId { get; set; }
        public GetScheduleByTeacherIdQuery(int teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
