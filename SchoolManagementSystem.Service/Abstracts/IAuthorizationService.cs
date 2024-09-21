using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using System.Security.Claims;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<bool> RoleExistsAsync(string roleName);
        public Task<GetUserRolesResponse> GetUserRolesResponseAsync(int UserId);
        public Task<GetUserRolesResponse> GetUserRolesResponseAsync(string userName);
        public Task UpdateUserRoles(GetUserRolesResponse userRoles);
        public Task<GetUserClaimsResponse> GetUserClaimsResponseAsync(int userId);
        public Task<GetUserClaimsResponse> GetUserClaimsResponseAsync(string userName);
        internal Task<List<Claim>> GetUserClaims(User user);
    }
}
