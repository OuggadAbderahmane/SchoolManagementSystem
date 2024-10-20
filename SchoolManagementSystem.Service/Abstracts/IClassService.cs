using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IClassService
    {
        public Task<GetClassResponse> GetClassByIdAsync(int Id);
        public Task<List<GetClassResponse>> GetClassesListAsync(int? LevelId, int? YearOfLevelId);
        public IQueryable<Class> GetClassesListIQueryable();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<string> GetClassInfo(int Id);
    }
}
