using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Semesters.Queries.Models
{
    public class GetSemestersListQuery : IRequest<Response<List<GetSemesterResponse>>>
    {
    }
}
