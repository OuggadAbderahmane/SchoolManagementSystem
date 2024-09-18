using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        public Task<GetClassResponse> GetClassByIdAsync(int Id);
        public Task<List<GetClassResponse>> GetClassesListAsync();
        public IQueryable<Class> GetClassesListIQueryable();
        public Task<string> GetClassInfo(int Id);
    }
}
