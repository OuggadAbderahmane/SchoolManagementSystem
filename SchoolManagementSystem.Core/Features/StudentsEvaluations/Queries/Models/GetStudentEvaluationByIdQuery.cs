using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models
{
    public class GetStudentEvaluationByIdQuery : IRequest<Response<GetStudentEvaluationResponse>>
    {
        public int Id { get; set; }
        public GetStudentEvaluationByIdQuery(int id)
        {
            Id = id;
        }

    }
}
