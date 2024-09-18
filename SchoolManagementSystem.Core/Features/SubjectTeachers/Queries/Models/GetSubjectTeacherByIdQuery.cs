using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Models
{
    public class GetSubjectTeacherByIdQuery : IRequest<Response<GetSubjectTeacherResponse>>
    {
        public int Id { get; set; }
        public GetSubjectTeacherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
