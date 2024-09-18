using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Sections.Queries.Models
{
    public class GetSectionByIdQuery : IRequest<Response<GetSectionResponse>>
    {
        public int Id { get; set; }
        public GetSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
