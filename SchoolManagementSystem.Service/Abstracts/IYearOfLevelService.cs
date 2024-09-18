using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IYearOfLevelService
    {
        public Task<GetYearOfLevelResponse> GetYearOfLevelByIdAsync(int Id);
        public Task<List<GetYearOfLevelResponse>> GetYearOfLevelsListAsync();
        public IQueryable<YearOfLevel> GetYearOfLevelsListIQueryable();

    }
}
