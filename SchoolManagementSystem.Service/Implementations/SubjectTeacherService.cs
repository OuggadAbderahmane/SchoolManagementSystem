using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class SubjectTeacherService : ISubjectTeacherService
    {
        #region Fields
        private readonly ISubjectTeacherRepository _SubjectTeacherRepository;
        #endregion

        #region Constructors
        public SubjectTeacherService(ISubjectTeacherRepository subjectTeacherRepository)
        {
            _SubjectTeacherRepository = subjectTeacherRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetSubjectTeacherResponse> GetSubjectTeacherByIdAsync(int Id)
        {
            return await _SubjectTeacherRepository.GetSubjectTeacherByIdAsync(Id);
        }

        public IQueryable<SubjectTeacher> GetSubjectTeachersListIQueryable()
        {
            return _SubjectTeacherRepository.GetSubjectTeachersListIQueryable();
        }

        public IQueryable<GetSubjectTeacherResponse> GetSubjectTeachersListResponse()
        {
            return _SubjectTeacherRepository.GetSubjectTeachersListResponse();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _SubjectTeacherRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<bool> IsSubjectTeacherExistAsync(int Subject, int Teacher)
        {
            return await _SubjectTeacherRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Subject && S.Id == Teacher);
        }

        public async Task<int> CreateSubjectTeacherAsync(SubjectTeacher subjectTeacher)
        {
            try
            {
                await _SubjectTeacherRepository.AddAsync(subjectTeacher);
                return subjectTeacher.Id;
            }
            catch
            {
                return -1;
            }
        }
        #endregion
    }
}
