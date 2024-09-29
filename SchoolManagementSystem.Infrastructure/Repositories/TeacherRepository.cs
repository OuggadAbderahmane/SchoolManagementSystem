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
    internal class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IHelperClass _helperClass;
        #endregion

        #region Constructors
        public TeacherRepository(AppDbContext dbContext, IHelperClass helperClass)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _helperClass = helperClass;
        }
        #endregion

        #region Handles Functions
        public async Task<GetAllTeacherInfoResponse> GetTeacherByIdAsync(int Id)
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return (await _dbContext.Teachers.AsNoTracking().Where(S => S.Id == Id).Select(S =>
                                            new GetAllTeacherInfoResponse
                                            {
                                                Id = S.Id,
                                                NationalCardNumber = S.NationalCardNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? "Male" : "Female",
                                                Salary = S.Salary,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                                Address = S.Address,
                                                Email = S.Email,
                                                Phone = S.Phone,
                                                DateOfBirth = S.DateOfBirth,
                                                PermanentWork = S.PermanentWork
                                            }).FirstOrDefaultAsync())!;
        }

        public IQueryable<GetTeacherResponse> GetTeachersListResponse()
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return _dbContext.Teachers.AsNoTracking().Select(S =>
                                            new GetTeacherResponse
                                            {
                                                Id = S.Id,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Salary = S.Salary,
                                                PermanentWork = S.PermanentWork,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null
                                            });
        }

        public IQueryable<Teacher> GetTeachersListIQueryable()
        {
            return _dbContext.Teachers.AsNoTracking();
        }

        public bool UpdateTeacherByQuery(int PersonId, decimal? Salary = null, bool? IsPermanentWorkAvtive = null)
        {
            if (Salary == null && IsPermanentWorkAvtive == null)
                return true;
            var parameters = new List<SqlParameter>();
            var query = new StringBuilder("UPDATE [dbo].[Teachers] SET ");

            if (Salary != null)
            {
                query.Append("Salary = @Salary, ");
                parameters.Add(new SqlParameter("@Salary", Salary));
            }
            if (IsPermanentWorkAvtive != null)
            {
                query.Append("IsPermanentWorkAvtive = @IsPermanentWorkAvtive ");
                parameters.Add(new SqlParameter("@IsPermanentWorkAvtive", IsPermanentWorkAvtive));
            }

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

        public async Task<bool> AddNewTeacherByPersonAsync(int PersonId, decimal Salary, bool IsPermanentWorkAvtive)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlAsync($"DECLARE @NewTeacherId INT;EXEC AddNewTeacherBaseOnPerson {PersonId}, {Salary} ,{IsPermanentWorkAvtive} , @NewTeacherId = @NewTeacherId OUTPUT");
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteTeacherAsync(int Id)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlAsync($"Exec dbo.DeleteTeacher {Id}");
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}