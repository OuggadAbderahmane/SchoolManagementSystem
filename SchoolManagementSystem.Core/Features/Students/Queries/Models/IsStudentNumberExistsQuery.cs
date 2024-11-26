using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class IsStudentNumberExistsQuery : IRequest<Response<bool>>
    {
        public string StudentNumber { get; set; }
        public IsStudentNumberExistsQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }
    }
}
