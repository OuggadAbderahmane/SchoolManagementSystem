using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        public Task<GetJobResponse> GetJobByIdAsync(int Id);
        public Task<string> GetJobNameByIdAsync(int Id);
        public Task<List<GetJobResponse>> GetJobsListAsync();
        public IQueryable<Job> GetJobsListIQueryable();
    }
}
