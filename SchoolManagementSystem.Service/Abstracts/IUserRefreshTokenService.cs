using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Helper;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IUserRefreshTokenService
    {
        public Task CreateUserRefreshTokenAsync(UserRefreshToken UserRefreshToken);
        public Task<bool> IsValidAsync(string RefreshTokenString);
        public Task<bool> IsUserIdExistAsync(int UserId);
        public Task<JwtAuthResult> GetJWTTokenWithRefresherAsync(User user);
        public Task<string> RefreshAccessTokenAsync(string RefreshTokenString);
    }
}
