using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Levels.Queries.Models
{
    public class GetLevelsListQuery : IRequest<Response<List<GetLevelResponse>>>
    {
    }
}
