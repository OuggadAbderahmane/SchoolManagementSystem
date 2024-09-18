using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IYearRepository : IGenericRepository<Year>
    {
        public IQueryable<Year> GetYearsListIQueryable();
        public Task<GetYearResponse> GetYearByIdAsync(int Id);
    }
}
