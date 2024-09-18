using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Models
{
    public class GetSubjectTeachersPaginatedListQuery : IRequest<Response<PaginatedResult<GetSubjectTeacherResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetSubjectTeachersPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
