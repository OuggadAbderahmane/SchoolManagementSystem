using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Models
{
    public class GetYearOfLevelByIdQuery : IRequest<Response<GetYearOfLevelResponse>>
    {
        public int Id { get; set; }
        public GetYearOfLevelByIdQuery(int id)
        {
            Id = id;
        }
    }
}
