using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.HelperClass;
using System.Text;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IClassRepository _classRepository;
        private readonly IHelperClass _helperClass;
        #endregion

        #region Constructors
        public StudentRepository(AppDbContext dbContext, IClassRepository classRepository, IHelperClass helperClass)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
            _helperClass = helperClass;
        }
        #endregion

        #region Handles Functions
        public async Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id)
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return (await _dbContext.Students.AsNoTracking().Include(x => x.Section).Where(S => S.Id == Id).Select(S =>
                                            new GetAllStudentInfoResponse
                                            {
                                                Id = S.Id,
                                                NationalCardNumber = S.NationalCardNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? "Male" : "Female",
                                                SectionName = S.Section == null ? null : S.Section.Name,
                                                classInfo = S.Section == null ? null : _classRepository.GetClassInfoIQueryable().Where(x => x.Id == S.Section.ClassId).First().ClassInfo,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                                Address = S.Address,
                                                DateOfBirth = S.DateOfBirth,
                                                IsActive = S.IsActive
                                            }).FirstOrDefaultAsync())!;
        }
        public IQueryable<GetStudentResponse> GetStudentsListResponse(string NationalCardNumber, string FirstName, string LastName, bool? Gender, int SectionId, int GuardianId, bool? IsActive)
        {
            var url = _helperClass.GetSchemeHost() + '/';
            IQueryable<Student> filter = _dbContext.Students.AsNoTracking().Include(x => x.Section);
            if (!NationalCardNumber.IsNullOrEmpty())
                filter = filter.Where(x => x.NationalCardNumber.Contains(NationalCardNumber));
            if (!FirstName.IsNullOrEmpty())
                filter = filter.Where(x => x.FirstName.Contains(FirstName));
            if (!LastName.IsNullOrEmpty())
                filter = filter.Where(x => x.LastName.Contains(LastName));
            if (Gender != null)
                filter = filter.Where(x => x.Gender == Gender);
            if (SectionId != 0)
                filter = filter.Where(x => x.SectionId == SectionId);
            if (GuardianId != 0)
                filter = filter.Where(x => x.GuardianId == GuardianId);
            if (IsActive != null)
                filter = filter.Where(x => x.IsActive == IsActive);

            return filter.Select(S =>
                                new GetStudentResponse
                                {
                                    Id = S.Id,
                                    FirstName = S.FirstName,
                                    LastName = S.LastName,
                                    SectionName = S.Section == null ? null : S.Section.Name,
                                    classInfo = S.Section == null ? null : _classRepository.GetClassInfoIQueryable().Where(x => x.Id == S.Section.ClassId).First().ClassInfo,
                                    ImagePath = S.ImagePath != null ? url + S.ImagePath : null
                                });

        }
        public IQueryable<Student> GetStudentsListIQueryable()
        {
            return _dbContext.Students.AsNoTracking();
        }
        public bool UpdateStudentByQuery(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsActive = null)
        {
            if (SectionId == null && GuardianId == null && IsActive == null)
                return true;
            var parameters = new List<SqlParameter>();
            var query = new StringBuilder("UPDATE [dbo].[Students] SET ");

            if (SectionId != null)
            {
                query.Append("SectionId = @SectionId, ");
                parameters.Add(new SqlParameter("@SectionId", SectionId));
            }
            if (GuardianId != null)
            {
                query.Append("GuardianId = @GuardianId, ");
                parameters.Add(new SqlParameter("@GuardianId", GuardianId));
            }
            if (IsActive != null)
            {
                query.Append("IsActive = @IsActive ");
                parameters.Add(new SqlParameter("@IsActive", IsActive));
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
        public async Task<bool> AddNewStudentByPersonAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool IsActive = true)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlAsync($"EXEC AddNewStudentBaseOnPerson {PersonId}, {(SectionId)} ,{(GuardianId)} , {IsActive}");
            }
            catch
            {
                return false;
            }

            return true;
        }
        public async Task<bool> DeleteStudentAsync(int Id)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlAsync($"Exec dbo.DeleteStudent {Id}");
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