using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Sections.Queries.Models
{
    public class GetSectionsPaginatedListQuery : IRequest<Response<PaginatedResult<GetSectionResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetSectionsPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
