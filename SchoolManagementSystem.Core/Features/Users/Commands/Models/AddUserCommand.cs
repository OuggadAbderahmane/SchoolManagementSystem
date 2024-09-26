using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int PersonId { get; set; }
        public List<string> Roles { get; set; }
    }
}
