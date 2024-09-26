using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Helper;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class SignInByUserNameCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
