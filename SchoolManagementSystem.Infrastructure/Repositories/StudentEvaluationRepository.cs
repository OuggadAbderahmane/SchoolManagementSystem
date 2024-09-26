using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.HelperClass;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class StudentEvaluationRepository : GenericRepository<StudentEvaluation>, IStudentEvaluationRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IClassRepository _classRepository;
        #endregion

        #region Constructors
        public StudentEvaluationRepository(AppDbContext dbContext, IClassRepository classRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<StudentEvaluation> GetStudentEvaluationsListIQueryable()
        {
            return _dbContext.StudentsEvaluations.AsNoTracking();
        }

        public async Task<List<GetGradeReport>> GetGradeReportAsync(int studentId, int yearId, int semesterId = 0)
        {
            var studentsEvaluationsIQueryable = _dbContext.StudentsEvaluations.Where(x => x.StudentId == studentId && x.YearId == yearId);
            if (semesterId != 0)
                studentsEvaluationsIQueryable = studentsEvaluationsIQueryable.Where(x => x.SemesterId == semesterId);

            var GradeReportGroupdBySemester = studentsEvaluationsIQueryable.GroupBy(x => x.SemesterId);

            return await GradeReportGroupdBySemester
                         .Select(x => new GetGradeReport
                         {
                             Semester = x.Select(x => x.Semester.Name).First(),
                             Evaluation = x.Select(y => new Evaluation
                             {
                                 StudentEvaluationId = y.Id,
                                 SubjectName = y.Subject.Name,
                                 ContinuousAssessment = y.ContinuousAssessment,
                                 FirstTest = y.FirstTest,
                                 SecondTest = y.SecondTest,
                                 Exam = y.Exam
                             }).ToList()
                         }).ToListAsync();
        }

        public async Task<GetStudentEvaluationResponse> GetStudentEvaluationByIdAsync(int Id)
        {
            return (await _dbContext.StudentsEvaluations.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Where(x => x.Id == Id).Select(helperClass.expressionStudentEvaluationResponse).FirstOrDefaultAsync())!;
        }

        public async Task<GetStudentEvaluationResponse> GetStudentEvaluationByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return (await _dbContext.StudentsEvaluations.AsNoTracking()
                .Where(S => S.StudentId == studentId && S.SubjectId == subjectId && S.SemesterId == semesterId && S.YearId == yearId)
                .Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(helperClass.expressionStudentEvaluationResponse).FirstOrDefaultAsync())!;
        }

        public IQueryable<GetStudentEvaluationResponse> GetStudentEvaluationsListResponse()
        {
            return _dbContext.StudentsEvaluations.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(helperClass.expressionStudentEvaluationResponse);
        }

        public async Task<List<GetStudentEvaluationResponse>> GetStudentEvaluationsListAsync()
        {
            return await _dbContext.StudentsEvaluations.AsNoTracking().Include(x => x.Student).Include(x => x.Year).Include(x => x.Subject).Include(x => x.Semester).Select(helperClass.expressionStudentEvaluationResponse).ToListAsync();
        }
        #endregion
    }
}
