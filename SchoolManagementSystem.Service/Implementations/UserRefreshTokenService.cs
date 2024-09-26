using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Helper;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class UserRefreshTokenService : IUserRefreshTokenService
    {
        #region Fields
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;
        #endregion

        #region Constructors
        public UserRefreshTokenService(IUserRefreshTokenRepository userRefreshTokenRepository, JwtOptions jwtOptions, UserManager<User> userManager, IAuthorizationService authorizationService)
        {
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _authorizationService = authorizationService;
            _jwtOptions = jwtOptions;
            _userManager = userManager;
        }
        #endregion

        #region Handles Functions
        public async Task CreateUserRefreshTokenAsync(UserRefreshToken UserRefreshToken)
        {
            await _userRefreshTokenRepository.AddAsync(UserRefreshToken);
        }
        public async Task<bool> IsValidAsync(string RefreshTokenString)
        {
            return (await _userRefreshTokenRepository.GetUserByRefreshToken(RefreshTokenString)) != null;
        }
        public async Task<bool> IsUserIdExistAsync(int UserId)
        {
            return await _userRefreshTokenRepository.IsUserIdExistAsync(UserId);
        }
        public async Task<JwtAuthResult> GetJWTTokenWithRefresherAsync(User user)
        {
            var userRefreshToken = new UserRefreshToken(userId: user.Id,
                                                        refreshTokenString: Guid.NewGuid().ToString("n"),
                                                        expireAt: DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshLifetime)
                                                        );

            var jwtAuthResult = new JwtAuthResult()
            {
                AccessToken = await _GetJWTTokenAsync(user),
                refreshToken = new RefreshToken()
                {
                    UserName = user.UserName,
                    TokenString = userRefreshToken.RefreshTokenString,
                    ExpireAt = userRefreshToken.ExpireAt
                },
            };

            await _userRefreshTokenRepository.AddAsync(userRefreshToken);

            return jwtAuthResult;
        }
        public async Task<string> RefreshAccessTokenAsync(string RefreshTokenString)
        {
            var User = await _userRefreshTokenRepository.GetUserByRefreshToken(RefreshTokenString);

            return (User != null) ? await _GetJWTTokenAsync(User) : null!;
        }
        private async Task<string> _GetJWTTokenAsync(User user)
        {
            var Claims = new List<Claim>() { new("UserName", user.UserName) };
            if (user.PersonId.HasValue)
                Claims.Add(new Claim("PersonId", ((int)user.PersonId).ToString()));

            var userClaims = await _authorizationService.GetUserClaims(user);
            Claims.AddRange(userClaims);
            foreach (var Role in user.Roles)
                Claims.Add(new(ClaimTypes.Role, Role.Name));

            var jwtToken = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, Claims, expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Lifetime), signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey)), SecurityAlgorithms.HmacSha256));
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return await Task.FromResult(AccessToken);
        }
        #endregion
    }
}
