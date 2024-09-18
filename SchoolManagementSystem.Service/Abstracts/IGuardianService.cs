using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IGuardianService
    {
        public Task<GetAllGuardianInfoResponse> GetGuardianByIdAsync(int Id);
        public IQueryable<GetGuardianResponse> GetGuardiansListResponse();
        public Task<bool> IsIdExistAsync(int Id);
        public IQueryable<Guardian> GetGuardiansListIQueryable();
        public Task<bool> CreateGuardianAsync(int PersonId, int? JobId = null);
        public Task<bool> UpdateGuardianAsync(int PersonId, int? JobId = null, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null, string? Email = null, string? Phone = null);
        public Task<int> CreateGuardianAsync(Guardian guardian);
    }
}
