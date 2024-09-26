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

        public async Task<List<GetPartsOfScheduleResponse>> GetScheduleBySectionIdAsync(int Id)
        {
            return await fromPartsOfScheduleViewToResponse(await _dbContext.GetPartsOfScheduleResponses.FromSql($"Exec dbo.GetScheduleBySectionId {Id}").ToArrayAsync());
        }

        private Task<List<GetPartsOfScheduleResponse>> fromPartsOfScheduleViewToResponse(GetPartsOfScheduleView[] view)
        {
            List<GetPartsOfScheduleResponse> getPartsOfScheduleResponses = new List<GetPartsOfScheduleResponse>();
            foreach (var item in view)
            {
                getPartsOfScheduleResponses.Add(new GetPartsOfScheduleResponse
                {
                    Day = int.Parse(item.Day!),
                    Session1 = toSession(item.Session1),
                    Session2 = toSession(item.Session2),
                    Session3 = toSession(item.Session3),
                    Session4 = toSession(item.Session4),
                    Session5 = toSession(item.Session5),
                    Session6 = toSession(item.Session6),
                    Session7 = toSession(item.Session7)
                });
            }
            return Task.FromResult(getPartsOfScheduleResponses);
        }

        private Session? toSession(string? session)
        {
            if (session == null)
                return null;
            int Id;
            int indexofpoint = session.IndexOf('.');
            int.TryParse(session.Substring(0, indexofpoint), out Id);
            return new Session { SubjectTeacherId = Id, Info = session.Substring(indexofpoint + 1, session.Length - 1 - indexofpoint) };
        }
        #endregion
    }
}