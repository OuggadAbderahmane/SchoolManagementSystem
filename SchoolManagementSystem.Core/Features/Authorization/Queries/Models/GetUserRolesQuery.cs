using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Authorization.Queries.Models
{
    public class GetUserRolesQuery : IRequest<Response<GetUserRolesResponse>>
    {
        public string UserNameOrId { get; set; }
        public GetUserRolesQuery(string userNameOrId)
        {
            UserNameOrId = userNameOrId;
        }
    }
}
