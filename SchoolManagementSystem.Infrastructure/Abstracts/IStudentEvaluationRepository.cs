using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IStudentEvaluationRepository : IGenericRepository<StudentEvaluation>
    {
        public Task<GetStudentEvaluationResponse> GetStudentEvaluationByIdAsync(int Id);
        public Task<List<GetGradeReport>> GetGradeReportAsync(int studentId, int yearId, int semesterId = 0);
        public Task<GetStudentEvaluationResponse> GetStudentEvaluationByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public IQueryable<GetStudentEvaluationResponse> GetStudentEvaluationsListResponse();
        public Task<List<GetStudentEvaluationResponse>> GetStudentEvaluationsListAsync();
        public IQueryable<StudentEvaluation> GetStudentEvaluationsListIQueryable();
    }
}
