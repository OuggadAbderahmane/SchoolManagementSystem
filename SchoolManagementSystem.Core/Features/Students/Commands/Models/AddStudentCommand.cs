using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<IdResponse>>
    {

        [RegularExpression(@"^[0-9][0-9]*$", ErrorMessage = "StudentNumber Must not has letters")]
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public required enGender Gender { get; set; }
        public int? SectionId { get; set; }
        public int? GuardianId { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public IFormFile? ImagePath { get; set; }
        public required bool IsActive { get; set; }
    }
}
