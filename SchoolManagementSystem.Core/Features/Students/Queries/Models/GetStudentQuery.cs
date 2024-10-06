using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentQuery : IRequest<Response<GetAllStudentInfoResponse>>
    {
    }
}
