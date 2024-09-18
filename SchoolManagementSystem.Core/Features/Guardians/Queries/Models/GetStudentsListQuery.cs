using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Models
{
    public class GetGuardiansListQuery : IRequest<Response<List<GetGuardianResponse>>>
    {
    }
}
