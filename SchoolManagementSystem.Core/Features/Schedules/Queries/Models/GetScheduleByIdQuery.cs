using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleByIdQuery : IRequest<Response<List<GetPartsOfScheduleResponse>>>
    {
        public int Id { get; set; }
        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
