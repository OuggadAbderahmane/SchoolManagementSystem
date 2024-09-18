using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Models
{
    public class GetGuardianByIdQuery : IRequest<Response<GetAllGuardianInfoResponse>>
    {
        public int Id { get; set; }
        public GetGuardianByIdQuery(int id)
        {
            Id = id;
        }
    }
}
