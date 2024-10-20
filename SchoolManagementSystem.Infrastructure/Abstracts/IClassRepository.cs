using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        public Task<GetClassResponse> GetClassByIdAsync(int Id);
        public IQueryable<GetClassResponse> GetClassInfoIQueryable(int? LevelId, int? YearOfLevelId);
        public IQueryable<GetClassResponse> GetClassInfoIQueryable();
        public Task<List<GetClassResponse>> GetClassesListAsync(int? LevelId, int? YearOfLevelId);
        public IQueryable<Class> GetClassesListIQueryable();
    }
}
