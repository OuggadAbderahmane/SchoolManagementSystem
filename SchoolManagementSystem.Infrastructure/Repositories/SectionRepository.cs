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
            return (await _dbContext.Sections.AsNoTracking().Select(x => new GetSectionResponse
            {
                Id = x.Id,
                SectionName = x.Name,
                Classinfo = _classRepository.GetClassInfo(x.ClassId).Result
            }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public IQueryable<GetSectionResponse> GetSectionsListResponse()
        {
            return _dbContext.Sections.AsNoTracking().Select(x => new GetSectionResponse
            {
                Id = x.Id,
                SectionName = x.Name,
                Classinfo = _classRepository.GetClassInfo(x.ClassId).Result
            });
        }
        public async Task<List<GetSectionResponse>> GetSectionsListAsync()
        {
            return await _dbContext.Sections.AsNoTracking().Select(x => new GetSectionResponse
            {
                Id = x.Id,
                SectionName = x.Name,
                Classinfo = _classRepository.GetClassInfo(x.ClassId).Result
            }).ToListAsync();
        }
        #endregion
    }
}
