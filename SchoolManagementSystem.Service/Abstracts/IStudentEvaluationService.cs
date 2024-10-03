using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentEvaluationService
    {
        public Task<GetStudentEvaluationResponse> GetStudentEvaluationByIdAsync(int Id);
        public Task<List<GetGradeReport>> GetGradeReportAsync(int studentId, int yearId, int semesterId = 0);
        public Task<GetStudentEvaluationResponse> GetStudentEvaluationByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public Task<List<GetStudentEvaluationResponse>> GetStudentEvaluationsListAsync();
        public IQueryable<GetStudentEvaluationResponse> GetStudentEvaluationsListResponse();
        public Task<int> CreateStudentEvaluationAsync(StudentEvaluation studentevaluation);
        public Task<bool> UpdateStudentEvaluationAsync(StudentEvaluation studentevaluation);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsExistByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public IQueryable<StudentEvaluation> GetStudentEvaluationsListIQueryable();
        public Task<int> DeleteByIdAsync(int Id);
    }
}
