using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ISubjectTeacherService
    {
        public Task<GetSubjectTeacherResponse> GetSubjectTeacherByIdAsync(int Id);
        public IQueryable<GetSubjectTeacherResponse> GetSubjectTeachersListResponse();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsSubjectTeacherExistAsync(int Subject, int Teacher);
        public Task<int> CreateSubjectTeacherAsync(SubjectTeacher subjectTeacher);
        public IQueryable<SubjectTeacher> GetSubjectTeachersListIQueryable();
    }
}
