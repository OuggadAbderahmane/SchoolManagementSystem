using MediatR;
using SchoolManagementSystem.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-._@+]*$", ErrorMessage = "UserName Must starts with a letter")]
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public int? PersonId { get; set; }
        public List<string> Roles { get; set; }
    }
}
