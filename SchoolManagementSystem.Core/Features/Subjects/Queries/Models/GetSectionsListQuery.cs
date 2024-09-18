using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectsListQuery : IRequest<Response<List<GetSubjectResponse>>>
    {
    }
}
