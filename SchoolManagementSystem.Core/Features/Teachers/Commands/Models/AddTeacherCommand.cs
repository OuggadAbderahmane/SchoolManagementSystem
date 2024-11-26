using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddTeacherCommand : IRequest<Response<IdResponse>>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required enGender Gender { get; set; }
        public required bool PermanentWork { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
    }
}
