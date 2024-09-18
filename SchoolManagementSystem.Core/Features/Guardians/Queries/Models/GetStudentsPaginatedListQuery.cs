using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Models
{
    public class GetGuardiansPaginatedListQuery : IRequest<Response<PaginatedResult<GetGuardianResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetGuardiansPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
