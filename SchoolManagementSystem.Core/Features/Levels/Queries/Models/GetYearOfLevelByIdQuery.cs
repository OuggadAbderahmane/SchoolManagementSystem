using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Levels.Queries.Models
{
    public class GetLevelByIdQuery : IRequest<Response<GetLevelResponse>>
    {
        public int Id { get; set; }
        public GetLevelByIdQuery(int id)
        {
            Id = id;
        }
    }
}
