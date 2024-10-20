using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class ClassService : IClassService
    {
        #region Fields
        private readonly IClassRepository _ClassRepository;
        #endregion

        #region Constructors
        public ClassService(IClassRepository ClassRepository)
        {
            _ClassRepository = ClassRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetClassResponse> GetClassByIdAsync(int Id)
        {
            return await _ClassRepository.GetClassByIdAsync(Id);
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _ClassRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<List<GetClassResponse>> GetClassesListAsync(int? LevelId, int? YearOfLevelId)
        {
            return await _ClassRepository.GetClassesListAsync(LevelId, YearOfLevelId);
        }

        public IQueryable<Class> GetClassesListIQueryable()
        {
            return _ClassRepository.GetClassesListIQueryable();
        }

        public async Task<string> GetClassInfo(int Id)
        {
            return (await _ClassRepository.GetClassInfoIQueryable().Where(x => x.Id == Id).FirstOrDefaultAsync())?.ClassInfo!;
        }
        #endregion
    }
}
