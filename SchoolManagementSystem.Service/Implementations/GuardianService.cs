using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class GuardianService : IGuardianService
    {
        #region Fields
        private readonly IGuardianRepository _guardianRepository;
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public GuardianService(IGuardianRepository guardianRepository, IPersonRepository personRepository)
        {
            _guardianRepository = guardianRepository;
            _personRepository = personRepository;
        }

        #endregion

        #region Handles Functions
        public Task<GetAllGuardianInfoResponse> GetGuardianByIdAsync(int Id)
        {
            return _guardianRepository.GetGuardianByIdAsync(Id);
        }

        public IQueryable<GetGuardianResponse> GetGuardiansListResponse()
        {
            return _guardianRepository.GetGuardiansListResponseAsync();
        }

        public IQueryable<Guardian> GetGuardiansListIQueryable()
        {
            return _guardianRepository.GetGuardiansListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _guardianRepository.GetTableAsNoTracking().AnyAsync(D => D.Id == Id);
        }

        public Task<bool> CreateGuardianAsync(int PersonId, int? JobId = null)
        {
            try
            {
                return _guardianRepository.AddNewGuardianByPerson(PersonId, JobId);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public async Task<int> CreateGuardianAsync(Guardian guardian)
        {
            try
            {
                await _guardianRepository.AddAsync(guardian);
                return guardian.Id;
            }
            catch
            {
                return -1;
            }
        }
        public async Task<bool> UpdateGuardianAsync(int PersonId, int? JobId = null, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null, string? Email = null, string? Phone = null)
        {
            var Transaction = _guardianRepository.BeginTransaction();

            if (!_guardianRepository.UpdateGuardianByQuery(PersonId, JobId) || !_personRepository.UpdatePersonByQuery(PersonId, NationalCardNumber, FirstName, LastName, Gender, DateOfBirth, Email, Phone, Address, ImagePath))
            {
                await Transaction.RollbackAsync();
                return false;
            }

            Transaction.Commit();
            return true;

        }
        #endregion
    }
}
