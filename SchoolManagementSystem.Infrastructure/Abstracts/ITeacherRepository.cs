using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        public Task<GetAllTeacherInfoResponse> GetTeacherByIdAsync(int Id);
        public IQueryable<GetTeacherResponse> GetTeachersListResponse();
        public IQueryable<Teacher> GetTeachersListIQueryable();
        public bool UpdateTeacherByQuery(int PersonId, decimal? Salary = null, bool? IsPermanentWorkAvtive = null);
        public Task<bool> AddNewTeacherByPerson(int PersonId, decimal Salary, bool IsPermanentWorkAvtive);
    }
}
