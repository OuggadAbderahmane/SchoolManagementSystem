using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IYearService
    {
        public IQueryable<Year> GetYearsListIQueryable();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsExistAsync(string value);
        public Task<GetYearResponse> GetYearByIdAsync(int Id);
        public IQueryable<GetYearResponse> GetYearsListResponse();
        public Task<int> CreateYearAsync(Year year);
        public Task<bool> UpdateYearAsync(Year year);
        public Task<int> DeleteByIdAsync(int Id);
    }
}
