using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IGuardianRepository : IGenericRepository<Guardian>
    {
        public Task<GetAllGuardianInfoResponse> GetGuardianByIdAsync(int Id);
        public IQueryable<GetGuardianResponse> GetGuardiansListResponseAsync();
        public IQueryable<Guardian> GetGuardiansListIQueryable();
        public bool UpdateGuardianByQuery(int PersonId, int? JobId = null);
        public Task<bool> AddNewGuardianByPerson(int PersonId, int? JobId = null);
    }
}
