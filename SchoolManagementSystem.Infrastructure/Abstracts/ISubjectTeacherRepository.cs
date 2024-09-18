using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ISubjectTeacherRepository : IGenericRepository<SubjectTeacher>
    {
        public Task<GetSubjectTeacherResponse> GetSubjectTeacherByIdAsync(int Id);
        public IQueryable<GetSubjectTeacherResponse> GetSubjectTeachersListResponse();
        public IQueryable<SubjectTeacher> GetSubjectTeachersListIQueryable();
    }
}
