using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public SemesterRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<GetSemesterResponse> GetSemesterByIdAsync(int Id)
        {
            return (await _dbContext.Semesters.AsNoTracking().Select(x => new GetSemesterResponse() { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public async Task<List<GetSemesterResponse>> GetSemestersListAsync()
        {
            return await _dbContext.Semesters.AsNoTracking().Select(x => new GetSemesterResponse() { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public IQueryable<Semester> GetSemestersListIQueryable()
        {
            return _dbContext.Semesters.AsNoTracking();
        }
        #endregion
    }
}
