using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IFinalExamRepository : IGenericRepository<FinalExam>
    {
        public Task<GetFinalExamResponse> GetFinalExamByIdAsync(int Id);
        public Task<GetFinalExamResponse> GetFinalExamByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public IQueryable<GetFinalExamResponse> GetFinalExamsListResponse();
        public Task<List<GetFinalExamResponse>> GetFinalExamsListAsync();
        public IQueryable<FinalExam> GetFinalExamsListIQueryable();
    }
}
