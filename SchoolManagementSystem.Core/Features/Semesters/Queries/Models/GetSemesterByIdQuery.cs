using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Semesters.Queries.Models
{
    public class GetSemesterByIdQuery : IRequest<Response<GetSemesterResponse>>
    {
        public int Id { get; set; }
        public GetSemesterByIdQuery(int id)
        {
            Id = id;
        }
    }
}
