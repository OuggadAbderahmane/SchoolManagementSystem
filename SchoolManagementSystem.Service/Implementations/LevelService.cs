using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class LevelService : ILevelService
    {
        #region Fields
        private readonly ILevelRepository _levelRepository;
        #endregion

        #region Constructors
        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetLevelResponse> GetLevelByIdAsync(int Id)
        {
            return await _levelRepository.GetLevelByIdAsync(Id);
        }

        public async Task<List<GetLevelResponse>> GetLevelsListAsync()
        {
            return await _levelRepository.GetLevelsListAsync();
        }

        public IQueryable<Level> GetLevelsListIQueryable()
        {
            return _levelRepository.GetLevelsListIQueryable();
        }
        #endregion
    }
}
