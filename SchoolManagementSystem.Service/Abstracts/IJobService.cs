using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IJobService
    {
        public Task<GetJobResponse> GetJobByIdAsync(int Id);
        public Task<string> GetJobNameByIdAsync(int Id);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<List<GetJobResponse>> GetJobsListAsync();
        public IQueryable<Job> GetJobsListIQueryable();
    }
}
