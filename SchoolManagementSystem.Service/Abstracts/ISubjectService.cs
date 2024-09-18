using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<GetSubjectResponse> GetSubjectByIdAsync(int Id);
        public Task<List<GetSubjectResponse>> GetSubjectsListAsync();
        public IQueryable<GetSubjectResponse> GetSubjectsListResponse();
        public Task<int> CreateSubjectAsync(Subject subject);
        public Task<bool> UpdateSubjectAsync(Subject subject);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsExistAsync(string? SubjectName, int? ClassId, int? Id = null);
        public IQueryable<Subject> GetSubjectsListIQueryable();
    }
}
