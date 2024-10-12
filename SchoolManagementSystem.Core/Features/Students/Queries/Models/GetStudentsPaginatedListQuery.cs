using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedListQuery : IRequest<Response<PaginatedResult<GetStudentResponse>>>
    {
        public string? NationalCardNumber { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public enGender? Gender { get; set; }
        public int SectionId { get; set; }
        public int GuardianId { get; set; }
        public bool? IsActive { get; set; }
    }
}
