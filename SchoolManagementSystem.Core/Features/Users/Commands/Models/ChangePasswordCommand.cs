using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
