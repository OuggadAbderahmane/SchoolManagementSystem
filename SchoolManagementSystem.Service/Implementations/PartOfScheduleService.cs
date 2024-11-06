using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class PartOfScheduleService : IPartOfScheduleService
    {
        #region Fields
        private readonly IPartOfScheduleRepository _PartOfScheduleRepository;
        private readonly ISubjectTeacherService _subjectTeacherService;
        private readonly ISectionService _SectionService;
        #endregion

        #region Constructors
        public PartOfScheduleService(IPartOfScheduleRepository PartOfScheduleRepository, ISectionService sectionService, ISubjectTeacherService subjectTeacherService)
        {
            _PartOfScheduleRepository = PartOfScheduleRepository;
            _SectionService = sectionService;
            _subjectTeacherService = subjectTeacherService;
        }
        #endregion

        #region Handles Functions
        public IQueryable<PartOfSchedule> GetPartOfSchedulesListIQueryable()
        {
            return _PartOfScheduleRepository.GetPartOfSchedulesListIQueryable();
        }

        public async Task<List<GetPartsOfStudentScheduleResponse>> GetSectionScheduleByIdAsync(int Id)
        {
            return await _PartOfScheduleRepository.GetSectionScheduleBydAsync(Id);
        }

        public async Task<List<GetPartsOfTeacherScheduleResponse>> GetTeacherScheduleByIdAsync(int Id)
        {
            return await _PartOfScheduleRepository.GetTeacherScheduleByIdAsync(Id);
        }

        public async Task<bool> IsSessionAvailableAsync(int sectionId, sbyte day, sbyte session)
        {
            return (await _PartOfScheduleRepository.GetTableAsNoTracking().FirstOrDefaultAsync(x => x.SectionId == sectionId && x.Day == day && x.Session == session)) == null;
        }

        public async Task<int> CreatePartOfScheduleAsync(PartOfSchedule partOfSchedule)
        {
            try
            {
                await _PartOfScheduleRepository.AddAsync(partOfSchedule);
                return partOfSchedule.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<bool> IsPartsOfScheduleExistAsync(int SubjectTeacherId, sbyte day, sbyte session)
        {
            return (await _PartOfScheduleRepository.GetTableAsNoTracking().FirstOrDefaultAsync(x => x.SubjectTeacherId == SubjectTeacherId && x.Day == day && x.Session == session)) == null;
        }

        public async Task<bool> IsSubjectTeacherAvailable(int SubjectTeacherId, sbyte day, sbyte session)
        {
            var teacherId = (await _subjectTeacherService.GetSubjectTeachersListIQueryable().Where(x => x.Id == SubjectTeacherId).FirstOrDefaultAsync())!.TeacherId;
            return await IsTeacherAvailable(teacherId, day, session);
        }

        public async Task<bool> IsTeacherAvailable(int teacherId, sbyte day, sbyte session)
        {
            var subjectTeacherList = _subjectTeacherService.GetSubjectTeachersListIQueryable().Include(x => x.PartOfSchedules);
            var result = await subjectTeacherList.Where(x => x.TeacherId == teacherId).AnyAsync(x => x.PartOfSchedules.Any(x => x.Day == day && x.Session == session));
            return !result;
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _PartOfScheduleRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<int> DeletePartOfScheduleAsync(int SectionId, sbyte Day, sbyte Session)
        {
            return await _PartOfScheduleRepository.GetTableAsNoTracking().Where(x => x.SectionId == SectionId && x.Day == Day && x.Session == Session).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteScheduleBySectionIdAsync(int SectionId)
        {
            return await _PartOfScheduleRepository.GetTableAsNoTracking().Where(x => x.SectionId == SectionId).ExecuteDeleteAsync();
        }

        public async Task<bool> IsSubjectTeacherAvailable(int SubjectTeacherId, int Id)
        {
            var teacherId = _subjectTeacherService.GetSubjectTeachersListIQueryable().Where(x => x.Id == SubjectTeacherId).First().TeacherId;
            var daySession = _PartOfScheduleRepository.GetTableAsNoTracking().Where(x => x.Id == Id).Select(x => new { x.Day, x.Session }).First();
            return await IsTeacherAvailable(teacherId, daySession.Day, daySession.Session);
        }

        public async Task<bool> UpdatePartOfScheduleAsync(PartOfSchedule partOfSchedule)
        {
            var updatePartOfSchedule = await _PartOfScheduleRepository.GetTableAsTracking().Where(x => x.Day == partOfSchedule.Day && x.Session == partOfSchedule.Session && x.SectionId == partOfSchedule.SectionId).FirstOrDefaultAsync();
            if (updatePartOfSchedule == null)
            {
                return await CreatePartOfScheduleAsync(partOfSchedule) != -1;
            }
            updatePartOfSchedule.SubjectTeacherId = partOfSchedule.SubjectTeacherId;
            try
            {
                await _PartOfScheduleRepository.UpdateAsync(updatePartOfSchedule);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
