using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class SubjectService : ISubjectService
    {
        #region Fields
        private readonly ISubjectRepository _subjectRepository;
        #endregion

        #region Constructors
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetSubjectResponse> GetSubjectByIdAsync(int Id)
        {
            return await _subjectRepository.GetSubjectByIdAsync(Id);
        }

        public IQueryable<GetSubjectResponse> GetSubjectsListResponse()
        {
            return _subjectRepository.GetSubjectsListResponse();
        }

        public IQueryable<Subject> GetSubjectsListIQueryable()
        {
            return _subjectRepository.GetSubjectsListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _subjectRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<bool> UpdateSubjectAsync(Subject subject)
        {
            var UpdateStudent = _subjectRepository.GetTableAsNoTracking().Single(S => S.Id == subject.Id);
            if (subject.Name != null) UpdateStudent.Name = subject.Name;
            if (subject.ClassId != 0) UpdateStudent.ClassId = subject.ClassId;
            return (await _subjectRepository.UpdateAsync(UpdateStudent) != 0);
        }

        public async Task<int> CreateSubjectAsync(Subject subject)
        {
            subject.Name = subject.Name.ToUpper();
            try
            {
                await _subjectRepository.AddAsync(subject);
                return subject.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<List<GetSubjectResponse>> GetSubjectsListAsync()
        {
            return await _subjectRepository.GetSubjectsListAsync();
        }
        public async Task<bool> IsExistAsync(string? SubjectName, int? ClassId, int? Id = null)
        {
            if (Id == null)
                return await _subjectRepository.GetTableAsNoTracking().AnyAsync(S => S.Name.ToUpper().Equals(SubjectName!.ToUpper()) && S.ClassId == ClassId);

            var Query = _subjectRepository.GetTableAsNoTracking().First(x => x.Id == Id);
            if (SubjectName != null) SubjectName = Query.Name;
            if (ClassId != null) ClassId = Query.ClassId;

            return await _subjectRepository.GetTableAsNoTracking().AnyAsync(S => S.Name.ToUpper().Equals(SubjectName!.ToUpper()) && S.ClassId == ClassId && S.Id != Id);
        }
        #endregion
    }
}
