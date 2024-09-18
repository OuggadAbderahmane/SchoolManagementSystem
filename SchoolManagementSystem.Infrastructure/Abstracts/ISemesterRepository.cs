using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ISemesterRepository : IGenericRepository<Semester>
    {
        public Task<GetSemesterResponse> GetSemesterByIdAsync(int Id);
        public Task<List<GetSemesterResponse>> GetSemestersListAsync();
        public IQueryable<Semester> GetSemestersListIQueryable();
    }
}
