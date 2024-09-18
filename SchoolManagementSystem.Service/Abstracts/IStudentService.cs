using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id);
        public IQueryable<GetStudentResponse> GetStudentsListResponse();
        public IQueryable<Student> GetStudentsListIQueryable();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> CreateStudentAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool IsAvtive = true);
        public Task<bool> UpdateStudentAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsAvtive = null, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null);
        public Task<int> CreateStudentAsync(Student student);
    }
}
