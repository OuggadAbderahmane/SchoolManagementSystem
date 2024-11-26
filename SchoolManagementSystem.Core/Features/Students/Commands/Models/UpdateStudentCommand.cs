using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public enGender? Gender { get; set; }
        public int? SectionId { get; set; }
        public int? GuardianId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public IFormFile? ImagePath { get; set; }
        public bool? IsActive { get; set; }
    }
}
