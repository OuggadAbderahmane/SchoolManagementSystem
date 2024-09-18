using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Jobs.Queries.Models
{
    public class GetJobsListQuery : IRequest<Response<List<GetJobResponse>>>
    {
    }
}
