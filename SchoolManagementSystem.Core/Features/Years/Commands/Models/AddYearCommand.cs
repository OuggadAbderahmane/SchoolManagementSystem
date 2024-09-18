using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Models
{
    public class AddYearCommand : IRequest<Response<IdResponse>>
    {
        public required string Value { get; set; }
        public required bool IsActive { get; set; }
    }
}
