using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Classes.Queries.Models
{
    public class GetClassesListQuery : IRequest<Response<List<GetClassResponse>>>
    {
    }
}
