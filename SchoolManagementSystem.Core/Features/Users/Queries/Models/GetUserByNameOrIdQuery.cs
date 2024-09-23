using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Users.Queries.Models
{
    public class GetUserByNameOrIdQuery : IRequest<Response<GetUserResponse>>
    {
        public string UserNameOrId { get; set; }
        public GetUserByNameOrIdQuery(string userNameOrId)
        {
            UserNameOrId = userNameOrId;
        }
    }
}
