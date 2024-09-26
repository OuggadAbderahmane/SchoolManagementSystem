using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? PersonId { get; set; }
    }
}
