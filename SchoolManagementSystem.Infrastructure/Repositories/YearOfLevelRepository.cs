using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class YearOfLevelRepository : GenericRepository<YearOfLevel>, IYearOfLevelRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public YearOfLevelRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<GetYearOfLevelResponse> GetYearOfLevelByIdAsync(int Id)
        {
            return (await _dbContext.YearOfLevels.AsNoTracking().Select(x => new GetYearOfLevelResponse() { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public async Task<List<GetYearOfLevelResponse>> GetYearOfLevelsListAsync()
        {
            return await _dbContext.YearOfLevels.AsNoTracking().Select(x => new GetYearOfLevelResponse() { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public IQueryable<YearOfLevel> GetYearOfLevelsListIQueryable()
        {
            return _dbContext.YearOfLevels.AsNoTracking();
        }
        #endregion
    }
}
