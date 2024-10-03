using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Models
{
    public class DeleteGuardianCommand : IRequest<Response<string>>
    {
        public DeleteGuardianCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
