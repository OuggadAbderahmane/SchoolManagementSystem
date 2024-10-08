using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Helper;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class SignInByUserNameCommand : IRequest<Response<JwtAuthResult>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
