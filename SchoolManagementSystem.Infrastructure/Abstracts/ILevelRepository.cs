using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        public Task<GetLevelResponse> GetLevelByIdAsync(int Id);
        public Task<List<GetLevelResponse>> GetLevelsListAsync();
        public IQueryable<Level> GetLevelsListIQueryable();
    }
}
