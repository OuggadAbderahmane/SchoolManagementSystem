using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Models
{
    public class UpdateGuardianCommand : IRequest<Response<string>>
    {
        public required int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public enGender? Gender { get; set; }
        public int? JobId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
    }
}
