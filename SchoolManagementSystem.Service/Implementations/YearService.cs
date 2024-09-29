using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class YearService : IYearService
    {
        #region Fields
        private readonly IYearRepository _yearRepository;
        #endregion

        #region Constructors
        public YearService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Year> GetYearsListIQueryable()
        {
            return _yearRepository.GetYearsListIQueryable();
        }

        public IQueryable<GetYearResponse> GetYearsListResponse()
        {
            return _yearRepository.GetTableAsNoTracking().Select(x => new GetYearResponse
            {
                Id = x.Id,
                Value = x.Value,
                IsActive = x.IsActive
            });
        }

        public async Task<int> CreateYearAsync(Year year)
        {
            try
            {
                await _yearRepository.AddAsync(year);
                return year.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<bool> UpdateYearAsync(Year year)
        {
            var UpdateStudent = _yearRepository.GetTableAsNoTracking().First(S => S.Id == year.Id);
            UpdateStudent.IsActive = year.IsActive;
            return (await _yearRepository.UpdateAsync(UpdateStudent) != 0);
        }

        public async Task<GetYearResponse> GetYearByIdAsync(int Id)
        {
            return await _yearRepository.GetYearByIdAsync(Id);
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _yearRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<int> DeleteByIdAsync(int Id)
        {
            return await _yearRepository.GetTableAsNoTracking().Where(D => D.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<bool> IsExistAsync(string value)
        {
            return await _yearRepository.GetTableAsNoTracking().AnyAsync(S => S.Value == value);
        }
        #endregion
    }
}
