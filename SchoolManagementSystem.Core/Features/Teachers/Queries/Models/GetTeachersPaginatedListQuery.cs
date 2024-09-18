using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeachersPaginatedListQuery : IRequest<Response<PaginatedResult<GetTeacherResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetTeachersPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
