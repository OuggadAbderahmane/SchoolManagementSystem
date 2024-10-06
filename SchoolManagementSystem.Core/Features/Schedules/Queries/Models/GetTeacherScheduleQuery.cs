using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class GetTeacherScheduleQuery : IRequest<Response<List<GetPartsOfTeacherScheduleResponse>>>
    {
    }
}
