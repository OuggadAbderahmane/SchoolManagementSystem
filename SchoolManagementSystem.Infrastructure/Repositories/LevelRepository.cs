using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class LevelRepository : GenericRepository<Level>, ILevelRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public LevelRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<GetLevelResponse> GetLevelByIdAsync(int Id)
        {
            return (await _dbContext.Levels.AsNoTracking().Select(x => new GetLevelResponse() { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public async Task<List<GetLevelResponse>> GetLevelsListAsync()
        {
            return await _dbContext.Levels.AsNoTracking().Select(x => new GetLevelResponse() { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public IQueryable<Level> GetLevelsListIQueryable()
        {
            return _dbContext.Levels.AsNoTracking();
        }
        #endregion
    }
}
