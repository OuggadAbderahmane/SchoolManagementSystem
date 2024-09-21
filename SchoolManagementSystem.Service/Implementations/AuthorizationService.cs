using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Helper;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Service.Abstracts;
using System.Security.Claims;

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
        public async Task<bool> CreateRoleAsync(Role role)
        {
            if (await _roleManager.RoleExistsAsync(role.Name.ToLower()))
                return false;
            role.Name = role.Name.ToLower();
            await _roleManager.CreateAsync(role);
            return true;
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName.ToLower());
        }

        public async Task<GetUserRolesResponse> GetUserRolesResponseAsync(int userId)
        {
            var UserIQueryable = _userManager.Users.AsNoTracking()
                                                    .Where(u => u.Id == userId);
            return await GetUserRolesResponseAsync(UserIQueryable);
        }

        public async Task<GetUserRolesResponse> GetUserRolesResponseAsync(string userName)
        {
            var UserIQueryable = _userManager.Users.AsNoTracking()
                                        .Where(u => u.UserName == userName);
            return await GetUserRolesResponseAsync(UserIQueryable);
        }

        private async Task<GetUserRolesResponse> GetUserRolesResponseAsync(IQueryable<User> userIQueryable)
        {
            return (await userIQueryable.Select(u => new GetUserRolesResponse
            {
                UserId = u.Id,
                UserName = u.UserName,
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
             .FirstOrDefaultAsync())!;
        }

        public async Task UpdateUserRoles(GetUserRolesResponse userRoles)
        {
            var Transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                User User;
                if (userRoles.UserName != null)
                    User = await _userManager.Users.Include(x => x.Roles).FirstAsync(x => x.Id == userRoles.UserId);
                else
                    User = await _userManager.Users.Include(x => x.Roles).FirstAsync(x => x.Id == userRoles.UserId);

                await _userManager.RemoveFromRolesAsync(User, User.Roles.Select(x => x.Name));

                await _userManager.AddToRolesAsync(User, userRoles.Roles.Select(x => x.Name));

                await Transaction.CommitAsync();
            }
            catch
            {
                Transaction.Rollback();
            }
        }

        public async Task<GetUserClaimsResponse> GetUserClaimsResponseAsync(int userId)
        {
            User user = await _userManager.Users.FirstAsync(x => x.Id == userId);
            return await GetUserClaimsResponseAsync(user);
        }

        public async Task<GetUserClaimsResponse> GetUserClaimsResponseAsync(string userName)
        {
            User user = await _userManager.Users.FirstAsync(x => x.UserName == userName);
            return await GetUserClaimsResponseAsync(user);
        }

        private async Task<GetUserClaimsResponse> GetUserClaimsResponseAsync(User user)
        {
            if (user == null)
                return null!;
            List<Claim> userClaims = await GetUserClaims(user);
            var Claims = new GetUserClaimsResponse();
            if (userClaims == null)
                return null!;
            Claims.UserId = user.Id;
            foreach (var claim in ClaimsStore.claims)
            {
                var c = new UserClaim
                {
                    Type = claim.Type
                };
                if (userClaims.Any(x => x.Type == claim.Type))
                    c.Value = true;
                else c.Value = false;
                Claims.Claims.Add(c);
            }
            return Claims;
        }

        public async Task<List<Claim>> GetUserClaims(User user)
        {
            var claims = new List<Claim>();
            if (await _appDbContext.Teachers.AnyAsync(x => x.Id == user.PersonId))
                claims.Add(new Claim("UserType", "Teacher"));
            if (await _appDbContext.Students.AnyAsync(x => x.Id == user.PersonId))
                claims.Add(new Claim("UserType", "Student"));
            if (await _appDbContext.Guardians.AnyAsync(x => x.Id == user.PersonId))
                claims.Add(new Claim("UserType", "Guardian"));
            return claims;
        }
        #endregion
    }
}
