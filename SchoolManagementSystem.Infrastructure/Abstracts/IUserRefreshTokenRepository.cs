using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken>
    {
        public new Task<int> AddAsync(UserRefreshToken UserRefreshToken);
        public Task<User> GetUserByRefreshToken(string RefreshTokenString);
        public Task<bool> IsUserIdExistAsync(int UserId);

    }
}
