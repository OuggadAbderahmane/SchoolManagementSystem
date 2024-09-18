using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Sections.Queries.Models
{
    public class GetSectionsListQuery : IRequest<Response<List<GetSectionResponse>>>
    {
    }
}
