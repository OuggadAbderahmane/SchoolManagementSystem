using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeachersListQuery : IRequest<Response<List<GetTeacherResponse>>>
    {
    }
}
