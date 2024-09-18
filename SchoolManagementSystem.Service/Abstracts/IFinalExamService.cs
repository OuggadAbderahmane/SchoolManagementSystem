using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IFinalExamService
    {
        public Task<GetFinalExamResponse> GetFinalExamByIdAsync(int Id);
        public Task<GetFinalExamResponse> GetFinalExamByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public Task<List<GetFinalExamResponse>> GetFinalExamsListAsync();
        public IQueryable<GetFinalExamResponse> GetFinalExamsListResponse();
        public Task<int> CreateFinalExamAsync(FinalExam finalexam);
        public Task<bool> UpdateFinalExamAsync(FinalExam finalexam);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsExistByInfoAsync(int studentId, int subjectId, int semesterId, int yearId);
        public IQueryable<FinalExam> GetFinalExamsListIQueryable();
    }
}
