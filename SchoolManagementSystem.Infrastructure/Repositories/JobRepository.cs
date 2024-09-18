using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class JobRepository : GenericRepository<Job>, IJobRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public JobRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<GetJobResponse> GetJobByIdAsync(int Id)
        {
            return (await _dbContext.Jobs.AsNoTracking().Select(x => new GetJobResponse() { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }
        public Task<string> GetJobNameByIdAsync(int Id)
        {
            return Task.FromResult(_dbContext.Jobs.AsNoTracking().Where(x => x.Id == Id).Select(x => x.Name).FirstOrDefault()!);
        }

        public async Task<List<GetJobResponse>> GetJobsListAsync()
        {
            return await _dbContext.Jobs.AsNoTracking().Select(x => new GetJobResponse() { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public IQueryable<Job> GetJobsListIQueryable()
        {
            return _dbContext.Jobs.AsNoTracking();
        }
        #endregion
    }
}
