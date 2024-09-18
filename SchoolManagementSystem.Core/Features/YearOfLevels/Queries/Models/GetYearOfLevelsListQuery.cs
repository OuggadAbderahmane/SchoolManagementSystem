using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Models
{
    public class GetYearOfLevelsListQuery : IRequest<Response<List<GetYearOfLevelResponse>>>
    {
    }
}
