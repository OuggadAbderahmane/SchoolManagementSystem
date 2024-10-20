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
            return (await GetClassInfoIQueryable().AsNoTracking().Where(x => x.Id == Id).FirstOrDefaultAsync())!;
        }

        public async Task<List<GetClassResponse>> GetClassesListAsync(int? LevelId, int? YearOfLevelId)
        {
            return await GetClassInfoIQueryable(LevelId, YearOfLevelId).AsNoTracking().ToListAsync();
        }

        public IQueryable<Class> GetClassesListIQueryable()
        {
            return _dbContext.Classes.AsNoTracking();
        }

        public IQueryable<GetClassResponse> GetClassInfoIQueryable()
        {
            return GetClassInfoIQueryable(null, null);
        }

        public IQueryable<GetClassResponse> GetClassInfoIQueryable(int? LevelId, int? YearOfLevelId)
        {
            var result = from classes in _dbContext.Classes
                         join levels in _dbContext.Levels on classes.LevelId equals levels.Id
                         join yearOfLevels in _dbContext.YearOfLevels on classes.YearOfLevelId equals yearOfLevels.Id
                         select new { classes.Id, levelId = classes.LevelId, yearOfLevelName = yearOfLevels.Name, levelName = levels.Name, yearOfLevelId = classes.YearOfLevelId, classes.NameOfSpecialization };
            if (LevelId.HasValue)
                result = result.Where(x => x.levelId == LevelId);
            if (YearOfLevelId.HasValue)
                result = result.Where(x => x.yearOfLevelId == YearOfLevelId);
            return result.Select(x => new GetClassResponse { Id = x.Id, ClassInfo = x.yearOfLevelName + " " + x.levelName + " " + x.NameOfSpecialization });
        }
        #endregion
    }
}
