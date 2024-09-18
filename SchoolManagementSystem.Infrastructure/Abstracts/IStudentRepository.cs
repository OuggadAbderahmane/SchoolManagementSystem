using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id);
        public IQueryable<GetStudentResponse> GetStudentsListResponse();
        public IQueryable<Student> GetStudentsListIQueryable();
        public bool UpdateStudentByQuery(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsAvtive = null);
        public Task<bool> AddNewStudentByPerson(int PersonId, int? SectionId = null, int? GuardianId = null, bool IsAvtive = true);
    }
}
