using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class FinalExamService : IFinalExamService
    {
        #region Fields
        private readonly IFinalExamRepository _finalexamRepository;
        #endregion

        #region Constructors
        public FinalExamService(IFinalExamRepository finalexamRepository)
        {
            _finalexamRepository = finalexamRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetFinalExamResponse> GetFinalExamByIdAsync(int Id)
        {
            return await _finalexamRepository.GetFinalExamByIdAsync(Id);
        }

        public async Task<GetFinalExamResponse> GetFinalExamByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return await _finalexamRepository.GetFinalExamByInfoAsync(studentId, subjectId, semesterId, yearId);
        }

        public IQueryable<GetFinalExamResponse> GetFinalExamsListResponse()
        {
            return _finalexamRepository.GetFinalExamsListResponse();
        }

        public IQueryable<FinalExam> GetFinalExamsListIQueryable()
        {
            return _finalexamRepository.GetFinalExamsListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _finalexamRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<bool> UpdateFinalExamAsync(FinalExam finalexam)
        {
            var UpdateStudent = _finalexamRepository.GetTableAsNoTracking().First(S => S.Id == finalexam.Id);
            UpdateStudent.FinalExamNote = finalexam.FinalExamNote;
            return (await _finalexamRepository.UpdateAsync(UpdateStudent) != 0);
        }

        public async Task<int> CreateFinalExamAsync(FinalExam finalexam)
        {
            try
            {
                await _finalexamRepository.AddAsync(finalexam);
                return finalexam.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<List<GetFinalExamResponse>> GetFinalExamsListAsync()
        {
            return await _finalexamRepository.GetFinalExamsListAsync();
        }

        public async Task<bool> IsExistByInfoAsync(int studentId, int subjectId, int semesterId, int yearId)
        {
            return await _finalexamRepository.GetTableAsNoTracking().AnyAsync(S => S.StudentId == studentId && S.SubjectId == subjectId && S.SemesterId == semesterId && S.YearId == yearId);
        }
        #endregion
    }
}