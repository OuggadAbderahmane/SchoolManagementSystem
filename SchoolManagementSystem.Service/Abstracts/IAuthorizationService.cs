using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<bool> CreateAsync(Role role);
        public Task<bool> RoleExistsAsync(string roleName);
        public Task<GetUserRolesResponse> GetUserRolesResponseAsync(int UserId);
        public Task UpdateUserRoles(GetUserRolesResponse UserRoles);

    }
}
