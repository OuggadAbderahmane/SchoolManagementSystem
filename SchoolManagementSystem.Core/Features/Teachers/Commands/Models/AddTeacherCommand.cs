using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddTeacherCommand : IRequest<Response<IdResponse>>
    {
        public string NationalCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public bool PermanentWork { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
    }
}
