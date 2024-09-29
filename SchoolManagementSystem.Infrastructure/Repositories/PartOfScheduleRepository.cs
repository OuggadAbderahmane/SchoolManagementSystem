using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class PartOfScheduleRepository : GenericRepository<PartOfSchedule>, IPartOfScheduleRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public PartOfScheduleRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public IQueryable<PartOfSchedule> GetPartOfSchedulesListIQueryable()
        {
            return _dbContext.partsOfSchedules.AsNoTracking();
        }

        public async Task<List<GetPartsOfStudentScheduleResponse>> GetSectionScheduleBydAsync(int Id)
        {
            return await fromPartsOfScheduleViewToStudentScheduleResponseAsync(await _dbContext.GetPartsOfScheduleResponses.FromSql($"Exec dbo.GetScheduleBySectionId {Id}").ToArrayAsync());

        }

        public async Task<List<GetPartsOfTeacherScheduleResponse>> GetTeacherScheduleByIdAsync(int Id)
        {
            return await fromPartsOfScheduleViewToTeacherScheduleResponseAsync(await _dbContext.GetPartsOfScheduleResponses.FromSql($"Exec dbo.GetScheduleByTeacherId {Id}").ToArrayAsync());

        }

        private async Task<List<GetPartsOfStudentScheduleResponse>> fromPartsOfScheduleViewToStudentScheduleResponseAsync(GetPartsOfScheduleView[] view)
        {
            List<GetPartsOfStudentScheduleResponse> getPartsOfScheduleResponses = new List<GetPartsOfStudentScheduleResponse>();
            foreach (var item in view)
            {
                getPartsOfScheduleResponses.Add(new GetPartsOfStudentScheduleResponse
                {
                    Day = int.Parse(item.Day),
                    Session1 = toStudentSession(item.Session1),
                    Session2 = toStudentSession(item.Session2),
                    Session3 = toStudentSession(item.Session3),
                    Session4 = toStudentSession(item.Session4),
                    Session5 = toStudentSession(item.Session5),
                    Session6 = toStudentSession(item.Session6),
                    Session7 = toStudentSession(item.Session7)
                });
            }
            return await Task.FromResult(getPartsOfScheduleResponses);
        }
        private StudentSession? toStudentSession(string? session)
        {
            if (session == null)
                return null;
            int Id;
            int indexofpoint = session.IndexOf('.');
            int.TryParse(session.Substring(0, indexofpoint), out Id);
            return new StudentSession { SubjectTeacherId = Id, Info = session.Substring(indexofpoint + 1, session.Length - 1 - indexofpoint) };
        }

        private async Task<List<GetPartsOfTeacherScheduleResponse>> fromPartsOfScheduleViewToTeacherScheduleResponseAsync(GetPartsOfScheduleView[] view)
        {
            List<GetPartsOfTeacherScheduleResponse> getPartsOfScheduleResponses = new List<GetPartsOfTeacherScheduleResponse>();
            foreach (var item in view)
            {
                getPartsOfScheduleResponses.Add(new GetPartsOfTeacherScheduleResponse
                {
                    Day = int.Parse(item.Day),
                    Session1 = toTeacherSession(item.Session1),
                    Session2 = toTeacherSession(item.Session2),
                    Session3 = toTeacherSession(item.Session3),
                    Session4 = toTeacherSession(item.Session4),
                    Session5 = toTeacherSession(item.Session5),
                    Session6 = toTeacherSession(item.Session6),
                    Session7 = toTeacherSession(item.Session7)
                });
            }
            return await Task.FromResult(getPartsOfScheduleResponses);
        }
        private TeacherSession? toTeacherSession(string? session)
        {
            if (session == null)
                return null;
            int Id;
            int indexofpoint = session.IndexOf('.');
            int.TryParse(session.Substring(0, indexofpoint), out Id);
            return new TeacherSession { SectionId = Id, Info = session.Substring(indexofpoint + 1, session.Length - 1 - indexofpoint) };
        }
        #endregion
    }
}