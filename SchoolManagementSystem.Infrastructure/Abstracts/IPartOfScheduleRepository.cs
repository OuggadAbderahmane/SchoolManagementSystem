using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IPartOfScheduleRepository : IGenericRepository<PartOfSchedule>
    {
        public Task<List<GetPartsOfStudentScheduleResponse>> GetSectionScheduleBydAsync(int Id);
        public Task<List<GetPartsOfTeacherScheduleResponse>> GetTeacherScheduleByIdAsync(int Id);
        public IQueryable<PartOfSchedule> GetPartOfSchedulesListIQueryable();
        //public bool UpdatePartOfScheduleByQuery(int PersonId, decimal? Salary = null, bool? IsPermanentWorkAvtive = null);
        //public Task<bool> AddNewPartOfScheduleByPerson(int PersonId, decimal Salary, bool IsPermanentWorkAvtive);
    }
}
