using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedListQuery : IRequest<Response<PaginatedResult<GetStudentResponse>>>
    {
        public int pageNumber { get; set; }
        public int LevelId { get; set; }
        public int YearOfLevelId { get; set; }
        public int ClassId { get; set; }
        public int pageSize { get; set; }
        public string? FullName { get; set; }
        public string? StudentNumber { get; set; }
        public enGender? Gender { get; set; }
        public int SectionId { get; set; }
        public int GuardianId { get; set; }
        public bool? IsActive { get; set; }
    }
}
