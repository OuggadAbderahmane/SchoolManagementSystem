using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : IRequest<Response<string>>
    {
        public required string UserNameOrId { get; set; }
        public List<string> RolesName { get; set; }
    }
}
