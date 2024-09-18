using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class JobService : IJobService
    {
        #region Fields
        private readonly IJobRepository _jobRepository;
        #endregion

        #region Constructors
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetJobResponse> GetJobByIdAsync(int Id)
        {
            return await _jobRepository.GetJobByIdAsync(Id);
        }

        public async Task<string> GetJobNameByIdAsync(int Id)
        {
            return await _jobRepository.GetJobNameByIdAsync(Id);
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _jobRepository.GetTableAsNoTracking().AnyAsync(D => D.Id == Id);
        }

        public async Task<List<GetJobResponse>> GetJobsListAsync()
        {
            return await _jobRepository.GetJobsListAsync();
        }

        public IQueryable<Job> GetJobsListIQueryable()
        {
            return _jobRepository.GetJobsListIQueryable();
        }
        #endregion
    }
}
