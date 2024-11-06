using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class SignInByUserNameCommand : IRequest<Response<string>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
