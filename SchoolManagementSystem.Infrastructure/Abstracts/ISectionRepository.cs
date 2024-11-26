using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        public Task<GetSectionResponse> GetSectionByIdAsync(int Id);
        public IQueryable<GetSectionResponse> GetSectionsListResponse(int? LevelId = null, int? YearOfLevelId = null, int? ClassId = null);
        public Task<List<GetSectionResponse>> GetSectionsListAsync(int? LevelId, int? YearOfLevelId, int? ClassId);
        public IQueryable<Section> GetSectionsListIQueryable();
    }
}
