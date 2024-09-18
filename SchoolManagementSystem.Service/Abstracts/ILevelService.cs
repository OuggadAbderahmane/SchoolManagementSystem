using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ILevelService
    {
        public Task<GetLevelResponse> GetLevelByIdAsync(int Id);
        public Task<List<GetLevelResponse>> GetLevelsListAsync();
        public IQueryable<Level> GetLevelsListIQueryable();
    }
}
