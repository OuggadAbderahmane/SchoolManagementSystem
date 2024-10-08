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

        public async Task<List<GetClassResponse>> GetClassesListAsync()
        {
            return await GetClassInfoIQueryable().AsNoTracking().ToListAsync();
        }

        public IQueryable<Class> GetClassesListIQueryable()
        {
            return _dbContext.Classes.AsNoTracking();
        }

        public IQueryable<GetClassResponse> GetClassInfoIQueryable()
        {
            return from classes in _dbContext.Classes
                   join levels in _dbContext.Levels on classes.LevelId equals levels.Id
                   join yearOfLevels in _dbContext.YearOfLevels on classes.YearOfLevelId equals yearOfLevels.Id
                   select new GetClassResponse { Id = classes.Id, ClassInfo = yearOfLevels.Name + " " + levels.Name + " " + classes.NameOfSpecialization };
        }
        #endregion
    }
}
