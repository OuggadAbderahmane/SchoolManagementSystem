using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Classes.Queries.Models
{
    public class GetClassByIdQuery : IRequest<Response<GetClassResponse>>
    {
        public int Id { get; set; }
        public GetClassByIdQuery(int id)
        {
            Id = id;
        }
    }
}
