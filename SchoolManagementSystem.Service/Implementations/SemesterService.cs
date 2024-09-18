using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class SemesterService : ISemesterService
    {
        #region Fields
        private readonly ISemesterRepository _semesterRepository;
        #endregion

        #region Constructors
        public SemesterService(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetSemesterResponse> GetSemesterByIdAsync(int Id)
        {
            return await _semesterRepository.GetSemesterByIdAsync(Id);
        }

        public async Task<List<GetSemesterResponse>> GetSemestersListAsync()
        {
            return await _semesterRepository.GetSemestersListAsync();
        }

        public IQueryable<Semester> GetSemestersListIQueryable()
        {
            return _semesterRepository.GetSemestersListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _semesterRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }
        #endregion
    }
}
