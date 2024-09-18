using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherByIdQuery : IRequest<Response<GetAllTeacherInfoResponse>>
    {
        public int Id { get; set; }
        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
