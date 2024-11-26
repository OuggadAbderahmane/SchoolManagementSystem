using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ISectionService
    {
        public Task<GetSectionResponse> GetSectionByIdAsync(int Id);
        public Task<List<GetSectionResponse>> GetSectionsListAsync(int? LevelId, int? YearOfLevelId, int? ClassId);
        public IQueryable<GetSectionResponse> GetSectionsListResponse();
        public Task<int> CreateSectionAsync(Section section);
        public Task<bool> UpdateSectionAsync(Section section);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsExistAsync(string? SectionName, int? ClassId, int? Id = null);
        public IQueryable<Section> GetSectionsListIQueryable();
        public Task<int> DeleteByIdAsync(int Id);
    }
}
