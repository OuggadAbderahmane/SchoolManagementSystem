using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class FinalExamRepository : GenericRepository<FinalExam>, IFinalExamRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IClassRepository _classRepository;
        #endregion

        #region Constructors
        public FinalExamRepository(AppDbContext dbContext, IClassRepository classRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<FinalExam> GetFinalExamsListIQueryable()
        {
            return _dbContext.FinalExams.AsNoTracking();
        }

        public async Task<GetFinalExamResponse> GetFinalExamByIdAsync(int Id)
        {
            return (await _dbContext.FinalExams.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(x => new GetFinalExamResponse
            {
                Id = x.Id,
                StudentFulName = x.Student.FirstName + x.Student.LastName,
                StudentId = x.StudentId,
                Semester = x.Semester.Name,
                SubjectName = x.Subject.Name,
                SubjectId = x.SubjectId,
                Year = x.Year.Value,
                FinalExamNote = x.FinalExamNote
            }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public async Task<GetFinalExamResponse> GetFinalExamByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return (await _dbContext.FinalExams.AsNoTracking()
                .Where(S => S.StudentId == studentId && S.SubjectId == subjectId && S.SemesterId == semesterId && S.YearId == yearId)
                .Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(x => new GetFinalExamResponse
                {
                    Id = x.Id,
                    StudentFulName = x.Student.FirstName + x.Student.LastName,
                    StudentId = studentId,
                    Semester = x.Semester.Name,
                    SubjectName = x.Subject.Name,
                    SubjectId = subjectId,
                    Year = x.Year.Value,
                    FinalExamNote = x.FinalExamNote
                }).FirstOrDefaultAsync())!;
        }

        public IQueryable<GetFinalExamResponse> GetFinalExamsListResponse()
        {
            return _dbContext.FinalExams.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(x => new GetFinalExamResponse
            {
                Id = x.Id,
                StudentFulName = x.Student.FirstName + x.Student.LastName,
                StudentId = x.StudentId,
                Semester = x.Semester.Name,
                SubjectName = x.Subject.Name,
                SubjectId = x.SubjectId,
                Year = x.Year.Value,
                FinalExamNote = x.FinalExamNote
            });
        }
        public async Task<List<GetFinalExamResponse>> GetFinalExamsListAsync()
        {
            return await _dbContext.FinalExams.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(x => new GetFinalExamResponse
            {
                Id = x.Id,
                StudentFulName = x.Student.FirstName + x.Student.LastName,
                StudentId = x.StudentId,
                Semester = x.Semester.Name,
                SubjectName = x.Subject.Name,
                SubjectId = x.SubjectId,
                Year = x.Year.Value,
                FinalExamNote = x.FinalExamNote
            }).ToListAsync();
        }
        #endregion
    }
}
