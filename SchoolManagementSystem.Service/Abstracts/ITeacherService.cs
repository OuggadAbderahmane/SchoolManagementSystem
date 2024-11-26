using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface ITeacherService
    {
        public Task<GetAllTeacherInfoResponse> GetTeacherByIdAsync(int Id);
        public IQueryable<GetTeacherResponse> GetTeachersListResponse(string FirstName, string LastName, bool? Gender, bool? PermanentWork);
        public IQueryable<Teacher> GetTeachersListIQueryable();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> CreateTeacherAsync(int PersonId, bool PermanentWork);
        public Task<bool> UpdateTeacherAsync(int PersonId, bool? PermanentWork = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null, string? Email = null, string? Phone = null);
        public Task<int> CreateTeacherAsync(Teacher teacher);
        public Task<bool> DeleteTeacherAsync(int Id);
    }
}
