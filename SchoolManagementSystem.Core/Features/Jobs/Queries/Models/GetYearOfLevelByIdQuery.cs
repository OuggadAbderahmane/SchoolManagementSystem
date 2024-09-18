using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Jobs.Queries.Models
{
    public class GetJobByIdQuery : IRequest<Response<GetJobResponse>>
    {
        public int Id { get; set; }
        public GetJobByIdQuery(int id)
        {
            Id = id;
        }
    }
}
