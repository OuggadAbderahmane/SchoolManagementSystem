using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Models
{
    public class GetGuardiansPaginatedListQuery : IRequest<Response<PaginatedResult<GetGuardianResponse>>>
    {
        public string? NationalCardNumber { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public enGender? Gender { get; set; }
        public int JobID { get; set; }
    }
}
