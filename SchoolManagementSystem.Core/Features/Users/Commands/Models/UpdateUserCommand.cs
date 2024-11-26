using MediatR;
using SchoolManagementSystem.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-._@+]*$", ErrorMessage = "UserName Must starts with a letter")]
        public string? UserName { get; set; }
        public int? PersonId { get; set; }
    }
}
