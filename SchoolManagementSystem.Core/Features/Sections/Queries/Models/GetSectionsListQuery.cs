using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Sections.Queries.Models
{
    public class GetSectionsListQuery : IRequest<Response<List<GetSectionResponse>>>
    {
        public int? LevelId { get; set; }
        public int? YearOfLevelId { get; set; }
        public int? ClassId { get; set; }
    }
}
