using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Models
{
    public class DeleteYearCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteYearCommand(int id)
        {
            Id = id;
        }
    }
}
