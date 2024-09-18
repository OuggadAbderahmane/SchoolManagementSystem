using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedListQuery : IRequest<Response<PaginatedResult<GetStudentResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetStudentsPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
