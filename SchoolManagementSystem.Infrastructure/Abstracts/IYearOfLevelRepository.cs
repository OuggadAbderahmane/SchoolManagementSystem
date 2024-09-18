using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IYearOfLevelRepository : IGenericRepository<YearOfLevel>
    {
        public Task<GetYearOfLevelResponse> GetYearOfLevelByIdAsync(int Id);
        public Task<List<GetYearOfLevelResponse>> GetYearOfLevelsListAsync();
        public IQueryable<YearOfLevel> GetYearOfLevelsListIQueryable();
    }
}
