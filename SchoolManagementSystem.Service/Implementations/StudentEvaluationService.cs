using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class StudentEvaluationService : IStudentEvaluationService
    {
        #region Fields
        private readonly IStudentEvaluationRepository _studentevaluationRepository;
        #endregion

        #region Constructors
        public StudentEvaluationService(IStudentEvaluationRepository studentevaluationRepository)
        {
            _studentevaluationRepository = studentevaluationRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetStudentEvaluationResponse> GetStudentEvaluationByIdAsync(int Id)
        {
            return await _studentevaluationRepository.GetStudentEvaluationByIdAsync(Id);
        }

        public async Task<List<GetGradeReport>> GetGradeReportAsync(int studentId, int yearId, int semesterId = 0)
        {
            return await _studentevaluationRepository.GetGradeReportAsync(studentId, yearId, semesterId);
        }

        public async Task<GetStudentEvaluationResponse> GetStudentEvaluationByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return await _studentevaluationRepository.GetStudentEvaluationByInfoAsync(studentId, subjectId, semesterId, yearId);
        }

        public IQueryable<GetStudentEvaluationResponse> GetStudentEvaluationsListResponse()
        {
            return _studentevaluationRepository.GetStudentEvaluationsListResponse();
        }

        public IQueryable<StudentEvaluation> GetStudentEvaluationsListIQueryable()
        {
            return _studentevaluationRepository.GetStudentEvaluationsListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _studentevaluationRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<bool> UpdateStudentEvaluationAsync(StudentEvaluation studentevaluation)
        {
            var UpdateStudent = _studentevaluationRepository.GetTableAsNoTracking().First(S => S.Id == studentevaluation.Id);
            if (UpdateStudent.ContinuousAssessment != null) UpdateStudent.ContinuousAssessment = studentevaluation.ContinuousAssessment;
            if (UpdateStudent.FirstTest != null) UpdateStudent.FirstTest = studentevaluation.FirstTest;
            if (UpdateStudent.SecondTest != null) UpdateStudent.SecondTest = studentevaluation.SecondTest;
            if (UpdateStudent.Exam != null) UpdateStudent.Exam = studentevaluation.Exam;
            return (await _studentevaluationRepository.UpdateAsync(UpdateStudent) != 0);
        }

        public async Task<int> CreateStudentEvaluationAsync(StudentEvaluation studentevaluation)
        {
            try
            {
                await _studentevaluationRepository.AddAsync(studentevaluation);
                return studentevaluation.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<List<GetStudentEvaluationResponse>> GetStudentEvaluationsListAsync()
        {
            return await _studentevaluationRepository.GetStudentEvaluationsListAsync();
        }

        public async Task<bool> IsExistByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return await _studentevaluationRepository.GetTableAsNoTracking().AnyAsync(S => S.StudentId == studentId && S.SubjectId == subjectId && S.SemesterId == semesterId && S.YearId == yearId);
        }

        public async Task<int> DeleteByIdAsync(int Id)
        {
            return await _studentevaluationRepository.GetTableAsNoTracking().Where(x => x.Id == Id).ExecuteDeleteAsync();
        }
        #endregion
    }
}