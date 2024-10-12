using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id);
        public IQueryable<GetStudentResponse> GetStudentsListResponse(string NationalCardNumber, string FirstName, string LastName, bool? Gender, int SectionId, int GuardianId, bool? IsActive);
        public IQueryable<Student> GetStudentsListIQueryable();
        public bool UpdateStudentByQuery(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsActive = null);
        public Task<bool> AddNewStudentByPersonAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool IsActive = true);
        public Task<bool> DeleteStudentAsync(int Id);
    }
}
