using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructors
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager, AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }
        #endregion

        #region Handles Functions
        public async Task<bool> CreateAsync(Role role)
        {
            if (await _roleManager.RoleExistsAsync(role.Name))
                return false;
            role.Name = role.Name.ToLower();
            await _roleManager.CreateAsync(role);
            return true;
        }
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName.ToLower());
        }
        public Task<GetUserRolesResponse> GetUserRolesResponseAsync(int UserId)
        {

            var UserRoles = _userManager.Users.AsNoTracking()
                                        .Where(u => u.Id == UserId)
                                        .Select(u => new GetUserRolesResponse
                                        {
                                            UserId = u.Id,
                                            Roles = _roleManager.Roles
                                                .GroupJoin(
                                                    u.Roles,
                                                    role => role.Id,
                                                    userRole => userRole.Id,
                                                    (role, userRoles) => new { Role = role, UserRoles = userRoles })
                                                .SelectMany(
                                                    grp => grp.UserRoles.DefaultIfEmpty(),
                                                    (grp, userRole) => new Roles
                                                    {
                                                        Name = grp.Role.Name,
                                                        HasIt = userRole != null
                                                    })
                                                .ToList()
                                        })
                                        .FirstOrDefault();

            return Task.FromResult(UserRoles!);
        }
        public async Task UpdateUserRoles(GetUserRolesResponse UserRoles)
        {
            var Transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var User = await _userManager.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == UserRoles.UserId);

                await _userManager.RemoveFromRolesAsync(User, User.Roles.Select(x => x.Name));

                await _userManager.AddToRolesAsync(User, UserRoles.Roles.Select(x => x.Name));

                await Transaction.CommitAsync();
            }
            catch
            {
                Transaction.Rollback();
            }
        }
        #endregion
    }
}
