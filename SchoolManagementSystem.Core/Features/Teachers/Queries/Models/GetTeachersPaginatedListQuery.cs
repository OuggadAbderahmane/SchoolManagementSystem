using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeachersPaginatedListQuery : IRequest<Response<PaginatedResult<GetTeacherResponse>>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public enGender? Gender { get; set; }
        public bool? PermanentWork { get; set; }
    }
}
