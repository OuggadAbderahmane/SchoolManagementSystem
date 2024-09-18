using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class YearRepository : GenericRepository<Year>, IYearRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public YearRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Year> GetYearsListIQueryable()
        {
            return _dbContext.Years.AsNoTracking();
        }

        public async Task<GetYearResponse> GetYearByIdAsync(int Id)
        {
            return (await _dbContext.Years.AsNoTracking().Select(x => new GetYearResponse() { Id = x.Id, Value = x.Value, IsActive = x.IsActive }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }
        #endregion
    }
}
