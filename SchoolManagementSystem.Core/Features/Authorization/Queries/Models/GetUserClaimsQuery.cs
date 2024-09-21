using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Authorization.Queries.Models
{
    public class GetUserClaimsQuery : IRequest<Response<GetUserClaimsResponse>>
    {
        public string UserNameOrId { get; set; }
        public GetUserClaimsQuery(string userNameOrId)
        {
            UserNameOrId = userNameOrId;
        }
    }
}
