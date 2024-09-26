using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Users.Queries.Models
{
    public class GetUsersListQuery : IRequest<Response<List<GetUserResponse>>>
    {
    }
}
