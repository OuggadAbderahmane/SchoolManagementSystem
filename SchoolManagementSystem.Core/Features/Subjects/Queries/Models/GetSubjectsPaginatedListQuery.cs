using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectsPaginatedListQuery : IRequest<Response<PaginatedResult<GetSubjectResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetSubjectsPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
