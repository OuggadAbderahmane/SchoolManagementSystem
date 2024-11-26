using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data;
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
            return (await _dbContext.Students.AsNoTracking().Include(x => x.Section).Include(x => x.Guardian).Where(S => S.Id == Id).Select(S =>
                                            new GetAllStudentInfoResponse
                                            {
                                                Id = S.Id,
                                                StudentNumber = S.StudentNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? enGender.MALE : enGender.FEMALE,
                                                SectionName = S.Section == null ? null : S.Section.Name,
                                                ClassInfo = S.Section == null ? null : _classRepository.GetClassInfoIQueryable().Where(x => x.Id == S.Section.ClassId).First().ClassInfo,
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                                Address = S.Address,
                                                GuardianId = S.GuardianId,
                                                GuardianFullName = S.Guardian != null ? S.Guardian.FirstName + ' ' + S.Guardian.LastName : null,
                                                GuardianPhone = S.Guardian != null ? S.Guardian.Phone : null,
                                                DateOfBirth = S.DateOfBirth,
                                                GuardianImagePath = S.Guardian != null ? S.Guardian.ImagePath != null ? url + S.Guardian.ImagePath : null : null,
                                                IsActive = S.IsActive
                                            }).FirstOrDefaultAsync())!;
        }
        public IQueryable<GetStudentResponse> GetStudentsListResponse(string StudentNumber, string FullName, bool? Gender, int SectionId, int ClassID, int LevelId, int YearOfLevelId, int GuardianId, bool? IsActive)
        {
            var url = _helperClass.GetSchemeHost() + '/';

            IQueryable<Student> filter = _dbContext.Students.AsNoTracking().Include(x => x.Section);

            if (!FullName.IsNullOrEmpty())
                filter = filter.Where(x => (x.FirstName + " " + x.LastName).Contains(FullName));
            if (!StudentNumber.IsNullOrEmpty())
                filter = filter.Where(x => x.StudentNumber.StartsWith(StudentNumber));

            if (SectionId != 0)
                filter = filter.Where(x => x.SectionId == SectionId);
            else if (ClassID != 0)
                filter = filter.Where(filter => filter.Section != null && filter.Section.ClassId == ClassID);
            else if (LevelId != 0)
            {
                filter = filter.Where(filter => filter.Section != null && filter.Section.Class.LevelId == LevelId);
                if (YearOfLevelId != 0)
                    filter = filter.Where(filter => filter.Section != null && filter.Section.Class.YearOfLevelId == YearOfLevelId);
            }

            if (Gender != null)
                filter = filter.Where(x => x.Gender == Gender);
            if (GuardianId != 0)
                filter = filter.Where(x => x.GuardianId == GuardianId);
            if (IsActive != null)
                filter = filter.Where(x => x.IsActive == IsActive);

            return filter.Select(S =>
                                new GetStudentResponse
                                {
                                    Id = S.Id,
                                    StudentNumber = S.StudentNumber,
                                    FirstName = S.FirstName,
                                    LastName = S.LastName,
                                    SectionName = S.Section == null ? null : S.Section.Name,
                                    Gender = S.Gender ? enGender.MALE : enGender.FEMALE,
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