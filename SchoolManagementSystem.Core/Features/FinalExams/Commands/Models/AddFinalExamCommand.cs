using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.FinalExams.Commands.Models
{
    public class AddFinalExamCommand : IRequest<Response<IdResponse>>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public double FinalExamNote { get; set; }
    }
}
