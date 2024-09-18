using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Models
{
    public class AddGuardianByPersonCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public int JobId { get; set; }
    }
}
