using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class LogoutCommand : IRequest<Response<string>>
    {

    }
}
