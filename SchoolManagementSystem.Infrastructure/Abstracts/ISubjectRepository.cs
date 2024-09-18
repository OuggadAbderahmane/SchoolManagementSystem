using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        public Task<GetSubjectResponse> GetSubjectByIdAsync(int Id);
        public Task<List<GetSubjectResponse>> GetSubjectsListAsync();
        public IQueryable<Subject> GetSubjectsListIQueryable();
        public IQueryable<GetSubjectResponse> GetSubjectsListResponse();
    }
}
