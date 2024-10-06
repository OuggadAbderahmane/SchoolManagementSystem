using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Models
{
    public class GetGuardianQuery : IRequest<Response<GetAllGuardianInfoResponse>>
    {
        
    }
}
