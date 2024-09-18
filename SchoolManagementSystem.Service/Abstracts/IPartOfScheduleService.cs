using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IPartOfScheduleService
    {
        public Task<List<GetPartsOfScheduleResponse>> GetScheduleBySectionIdAsync(int Id);
        public IQueryable<PartOfSchedule> GetPartOfSchedulesListIQueryable();
        public Task<bool> IsSessionAvailableAsync(int sectionId, sbyte day, sbyte session);
        public Task<bool> IsSubjectTeacherAvailable(int SubjectTeacherId, sbyte day, sbyte session);
        public Task<bool> IsSubjectTeacherAvailable(int SubjectTeacherId, int Id);
        public Task<bool> IsPartsOfScheduleExistAsync(int SubjectTeacherId, sbyte day, sbyte session);
        public Task<bool> IsTeacherAvailable(int teacherId, sbyte day, sbyte session);
        public Task<bool> IsIdExistAsync(int Id);
        public Task<int> CreatePartOfScheduleAsync(PartOfSchedule partOfSchedule);
        public Task<bool> UpdatePartOfScheduleAsync(PartOfSchedule partOfSchedule);
    }
}
