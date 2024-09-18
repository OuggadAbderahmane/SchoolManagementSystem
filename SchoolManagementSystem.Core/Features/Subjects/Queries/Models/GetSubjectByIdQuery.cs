using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdQuery : IRequest<Response<GetSubjectResponse>>
    {
        public int Id { get; set; }
        public GetSubjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
