using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<IdResponse>>
    {
        public required string NationalCardNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public int? SectionId { get; set; }
        public int? GuardianId { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public IFormFile? ImagePath { get; set; }
        public required bool IsActive { get; set; }
    }
}
