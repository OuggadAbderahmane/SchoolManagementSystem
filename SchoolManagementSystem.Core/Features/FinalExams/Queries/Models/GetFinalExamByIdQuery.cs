using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.FinalExams.Queries.Models
{
    public class GetFinalExamByIdQuery : IRequest<Response<GetFinalExamResponse>>
    {
        public int Id { get; set; }
        public GetFinalExamByIdQuery(int id)
        {
            Id = id;
        }
    }
}
