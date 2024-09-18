using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class YearOfLevelService : IYearOfLevelService
    {
        #region Fields
        private readonly IYearOfLevelRepository _yearOfLevelRepository;
        #endregion

        #region Constructors
        public YearOfLevelService(IYearOfLevelRepository yearOfLevelRepository)
        {
            _yearOfLevelRepository = yearOfLevelRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetYearOfLevelResponse> GetYearOfLevelByIdAsync(int Id)
        {
            return await _yearOfLevelRepository.GetYearOfLevelByIdAsync(Id);
        }

        public async Task<List<GetYearOfLevelResponse>> GetYearOfLevelsListAsync()
        {
            return await _yearOfLevelRepository.GetYearOfLevelsListAsync();
        }

        public IQueryable<YearOfLevel> GetYearOfLevelsListIQueryable()
        {
            return _yearOfLevelRepository.GetYearOfLevelsListIQueryable();
        }
        #endregion
    }
}
