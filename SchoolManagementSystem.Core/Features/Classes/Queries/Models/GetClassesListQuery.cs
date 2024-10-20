using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Classes.Queries.Models
{
    public class GetClassesListQuery : IRequest<Response<List<GetClassResponse>>>
    {
        public int? LevelId { get; set; }
        public int? YearOfLevelId { get; set; }
    }
}
