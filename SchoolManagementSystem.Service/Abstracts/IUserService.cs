using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IUserService
    {
        public Task<GetUserResponse> GetUserByIdAsync(int Id);
        public IQueryable<User> GetUsersListQueryable();
        public Task<bool> IsUserNameExistAsync(string name, int? Id = null);
        public Task<bool> IsPersonIdExistAsync(int PersonId, int? Id = null);
        public Task<bool> CreateAsync(User user, string password, List<string> roles);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> IsPasswordCorrectAsync(int Id, string password);
        public Task<bool?> UpdateUserPasswordAsync(int userId, string Newpassword, string Currentpassword);
        //public Task<int> DeleteByIdAsync(int Id);
        public Task<bool> IsIdExistAsync(int Id);
    }
}
