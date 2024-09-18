using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.FinalExams.Commands.Models
{
    public class UpdateFinalExamCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public double FinalExamNote { get; set; }
    }
}
