using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public ClassRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<GetClassResponse> GetClassByIdAsync(int Id)
        {
            return (await _dbContext.Classes.AsNoTracking().Select(x => new GetClassResponse() { Id = x.Id, ClassInfo = GetClassInfo(x.Id).Result }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public async Task<List<GetClassResponse>> GetClassesListAsync()
        {
            return await _dbContext.Classes.AsNoTracking().Select(x => new GetClassResponse() { Id = x.Id, ClassInfo = _dbContext.GetClassInfo(x.Id) }).ToListAsync();
        }

        public IQueryable<Class> GetClassesListIQueryable()
        {
            return _dbContext.Classes.AsNoTracking();
        }

        public Task<string> GetClassInfo(int Id)
        {
            return Task.FromResult(_dbContext.GetClassInfo(Id)!);
        }
        #endregion
    }
}
