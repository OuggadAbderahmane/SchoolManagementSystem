using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        #endregion

        #region Handles Functions
        public async Task<GetUserResponse> GetUserByIdAsync(int Id)
        {
            return (await _userRepository.GetTableAsNoTracking()
                                        .Select(S => new GetUserResponse()
                                        {
                                            Id = S.Id,
                                            UserName = S.UserName,
                                            PersonId = S.PersonId
                                        })
                                        .FirstOrDefaultAsync(S => S.Id == Id))!;
        }

        public IQueryable<User> GetUsersListQueryable()
        {
            return _userRepository.GetTableAsNoTracking();
        }

        public async Task<bool> IsUserNameExistAsync(string name, int? Id = null)
        {
            if (Id != null)
                return await _userRepository.GetTableAsNoTracking().AnyAsync(U => U.UserName.Equals(name) && U.Id != Id);
            return await _userRepository.GetTableAsNoTracking().AnyAsync(U => U.UserName.Equals(name));
        }

        public async Task<bool> IsPersonIdExistAsync(int PersonId, int? Id = null)
        {
            if (Id != null)
                return await _userRepository.GetTableAsNoTracking().AnyAsync(U => U.PersonId == PersonId && U.Id != Id);
            return await _userRepository.GetTableAsNoTracking().AnyAsync(U => U.PersonId == PersonId);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var UpdateUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (UpdateUser == null)
                return false;
            if (user.UserName != null) UpdateUser.UserName = user.UserName;
            if (user.PersonId != null) UpdateUser.PersonId = user.PersonId;
            var result = await _userManager.UpdateAsync(UpdateUser);
            return result.Succeeded;
        }

        public async Task<bool?> UpdateUserPasswordAsync(int userId, string Newpassword, string Currentpassword)
        {
            var UpdateUser = await _userManager.FindByIdAsync(userId.ToString());
            if (UpdateUser == null)
                return false;
            if (!await IsPasswordCorrectAsync(userId, Currentpassword))
                return null;
            UpdateUser.PasswordHash = _userManager.PasswordHasher.HashPassword(UpdateUser, Newpassword);
            var result = await _userManager.UpdateAsync(UpdateUser);
            return result.Succeeded;
        }

        public async Task<bool> IsPasswordCorrectAsync(int Id, string password)
        {
            var User = await _userManager.FindByIdAsync(Id.ToString());
            if (User == null) return false;

            var PasswordHashed = await _userManager.CheckPasswordAsync(User, password);
            return PasswordHashed;
        }

        public async Task<bool> CreateAsync(User user, string password, List<string> roles)
        {
            await _userManager.CreateAsync(user, password);
            return (await _userManager.AddToRolesAsync(user, roles.Select(x => x.ToLower()))).Succeeded;
        }

        public async Task<int> DeleteByIdAsync(int Id)
        {
            return await _userRepository.GetTableAsNoTracking().Where(D => D.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _userRepository.GetTableAsNoTracking().AnyAsync(U => U.Id == Id);
        }
        #endregion
    }
}
