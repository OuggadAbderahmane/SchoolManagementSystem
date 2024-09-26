using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public UserRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
    }
}
