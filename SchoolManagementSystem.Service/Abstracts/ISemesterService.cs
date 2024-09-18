using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ISemesterService
    {
        public Task<GetSemesterResponse> GetSemesterByIdAsync(int Id);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<List<GetSemesterResponse>> GetSemestersListAsync();
        public IQueryable<Semester> GetSemestersListIQueryable();
    }
}
