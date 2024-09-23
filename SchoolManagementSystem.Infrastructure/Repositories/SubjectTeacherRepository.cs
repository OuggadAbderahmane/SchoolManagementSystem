using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.HelperClass;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class SubjectTeacherRepository : GenericRepository<SubjectTeacher>, ISubjectTeacherRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public SubjectTeacherRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public IQueryable<SubjectTeacher> GetSubjectTeachersListIQueryable()
        {
            return _dbContext.SubjectTeachers.AsNoTracking();
        }

        public IQueryable<GetSubjectTeacherResponse> GetSubjectTeachersListResponse()
        {
            return _dbContext.SubjectTeachers.Include(x => x.Teacher).Include(x => x.Subject).AsNoTracking().Select(helperClass.expressionSubjectTeacherResponse);
        }

        public async Task<GetSubjectTeacherResponse> GetSubjectTeacherByIdAsync(int Id)
        {
            return (await _dbContext.SubjectTeachers.Include(x => x.Teacher).Include(x => x.Subject).AsNoTracking().Select(helperClass.expressionSubjectTeacherResponse).FirstOrDefaultAsync(x => x.Id == Id))!;
        }
        #endregion
    }
}