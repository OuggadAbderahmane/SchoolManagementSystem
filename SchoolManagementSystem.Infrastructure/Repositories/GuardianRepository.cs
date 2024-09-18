using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.HelperClass;
using System.Text;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class GuardianRepository : GenericRepository<Guardian>, IGuardianRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IHelperClass _helperClass;
        #endregion

        #region Constructors
        public GuardianRepository(AppDbContext dbContext, IHelperClass helperClass)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _helperClass = helperClass;
        }
        #endregion

        #region Handles Functions
        public async Task<GetAllGuardianInfoResponse> GetGuardianByIdAsync(int Id)
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return (await _dbContext.Guardians.AsNoTracking().Include(g => g.Job).Where(S => S.Id == Id).Select(S =>
                                            new GetAllGuardianInfoResponse
                                            {
                                                Id = S.Id,
                                                NationalCardNumber = S.NationalCardNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? "Male" : "Female",
                                                JobName = S.Job.Name,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                                Address = S.Address,
                                                Email = S.Email,
                                                Phone = S.Phone,
                                                DateOfBirth = S.DateOfBirth,
                                            }).FirstOrDefaultAsync())!;
        }
        public IQueryable<GetGuardianResponse> GetGuardiansListResponseAsync()
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return _dbContext.Guardians.AsNoTracking().Include(g => g.Job).Select(S =>
                                            new GetGuardianResponse
                                            {
                                                Id = S.Id,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                JobName = S.Job.Name,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                            });
        }
        public IQueryable<Guardian> GetGuardiansListIQueryable()
        {
            return _dbContext.Guardians.AsNoTracking();
        }
        public bool UpdateGuardianByQuery(int PersonId, int? JobId = null)
        {
            if (JobId == null)
                return true;
            var parameters = new List<SqlParameter>();
            var query = new StringBuilder("UPDATE [dbo].[Guardians] SET ");

            if (JobId != null)
            {
                query.Append("JobId = @JobId, ");
                parameters.Add(new SqlParameter("@JobId", JobId));
            }
            // Remove the trailing comma and space
            if (query[query.Length - 2] == ',')
            {
                query.Remove(query.Length - 2, 2);
            }

            query.Append(" WHERE Id = @PersonId");
            parameters.Add(new SqlParameter("@PersonId", PersonId));
            try
            {
                _dbContext.Database.ExecuteSqlRaw(query.ToString(), parameters.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Task<bool> AddNewGuardianByPerson(int PersonId, int? JobId = null)
        {
            try
            {
                _dbContext.Database.ExecuteSql($"DECLARE @NewGuardianId INT;EXEC AddNewGuardianBaseOnPerson {PersonId}, {(JobId)} @NewGuardianId = @NewGuardianId OUTPUT");
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
        #endregion
    }
}