using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Years.Queries.Models
{
    public class GetYearByIdQuery : IRequest<Response<GetYearResponse>>
    {
        public int Id { get; set; }
        public GetYearByIdQuery(int id)
        {
            Id = id;
        }
    }
}
