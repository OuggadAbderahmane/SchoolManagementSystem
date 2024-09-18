using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetAllStudentInfoResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
