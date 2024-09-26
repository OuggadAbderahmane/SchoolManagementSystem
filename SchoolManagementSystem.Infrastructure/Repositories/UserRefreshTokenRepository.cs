using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public UserRefreshTokenRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public override async Task<int> AddAsync(UserRefreshToken UserRefreshToken)
        {
            return await base.AddAsync(UserRefreshToken);
        }

        public async Task<User> GetUserByRefreshToken(string RefreshTokenString)
        {
            var result = await GetTableAsNoTracking().Include(x => x.User).Select(v => new
            {
                v.Id,
                v.RefreshTokenString,
                v.ExpireAt,
                UserId = v.User.Id
            }).FirstOrDefaultAsync(x => x.RefreshTokenString == RefreshTokenString);

            if (result == null) return null!;

            if (result.ExpireAt < DateTime.UtcNow)
            {
                await _dbContext.UserRefreshTokens.Where(x => x.Id == result.Id).ExecuteDeleteAsync();
                return null!;
            }

            return _dbContext.Users.Include(x => x.Roles)
                                    .Select(x => new User
                                    {
                                        Id = x.Id,
                                        UserName = x.UserName,
                                        PersonId = x.PersonId,
                                        Roles = x.Roles.Select(x => new Role
                                        {
                                            Id = x.Id,
                                            Name = x.Name
                                        }).ToList(),
                                    }).Where(x => x.Id == result.UserId).First();
        }

        public async Task<bool> IsUserIdExistAsync(int UserId)
        {
            return await GetTableAsNoTracking().AnyAsync(x => x.UserId == UserId);
        }
        #endregion
    }
}
