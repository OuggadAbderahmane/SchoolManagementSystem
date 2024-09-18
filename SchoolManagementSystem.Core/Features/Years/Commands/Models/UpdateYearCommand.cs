using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Models
{
    public class UpdateYearCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public required bool IsActive { get; set; }
    }
}
