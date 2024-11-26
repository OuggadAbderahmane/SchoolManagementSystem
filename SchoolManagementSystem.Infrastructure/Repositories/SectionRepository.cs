using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IClassRepository _classRepository;
        #endregion

        #region Constructors
        public SectionRepository(AppDbContext dbContext, IClassRepository classRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Section> GetSectionsListIQueryable()
        {
            return _dbContext.Sections.AsNoTracking();
        }

        public async Task<GetSectionResponse> GetSectionByIdAsync(int Id)
        {
            return (await GetSectionsListResponse().Where(x => x.Id == Id).FirstOrDefaultAsync())!;
        }

        public IQueryable<GetSectionResponse> GetSectionsListResponse(int? LevelId = null, int? YearOfLevelId = null, int? ClassId = null)
        {
            return _dbContext.Sections.AsNoTracking().Join(ClassId.HasValue ?
                _classRepository.GetClassInfoIQueryable().Where(x => x.Id == ClassId)
                : _classRepository.GetClassInfoIQueryable(LevelId, YearOfLevelId),
                x => x.ClassId, x => x.Id, (S, C) => new GetSectionResponse
                {
                    Id = S.Id,
                    SectionName = S.Name,
                    Classinfo = C.ClassInfo
                });
        }

        public async Task<List<GetSectionResponse>> GetSectionsListAsync(int? LevelId, int? YearOfLevelId, int? ClassId)
        {
            return await GetSectionsListResponse(LevelId, YearOfLevelId, ClassId).ToListAsync();
        }
        #endregion
    }
}
