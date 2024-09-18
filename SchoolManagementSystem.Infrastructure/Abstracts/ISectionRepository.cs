using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        public Task<GetSectionResponse> GetSectionByIdAsync(int Id);
        public IQueryable<GetSectionResponse> GetSectionsListResponse();
        public Task<List<GetSectionResponse>> GetSectionsListAsync();
        public IQueryable<Section> GetSectionsListIQueryable();
    }
}
