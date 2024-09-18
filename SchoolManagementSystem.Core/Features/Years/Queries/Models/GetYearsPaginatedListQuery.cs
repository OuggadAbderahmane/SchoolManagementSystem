using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Years.Queries.Models
{
    public class GetYearsPaginatedListQuery : IRequest<Response<PaginatedResult<GetYearResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetYearsPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
