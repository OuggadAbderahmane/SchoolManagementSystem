using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IClassRepository _classRepository;
        #endregion

        #region Constructors
        public SubjectRepository(AppDbContext dbContext, IClassRepository classRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Subject> GetSubjectsListIQueryable()
        {
            return _dbContext.Subjects.AsNoTracking();
        }

        public async Task<GetSubjectResponse> GetSubjectByIdAsync(int Id)
        {
            return (await GetSubjectsListResponse().Where(x => x.Id == Id).FirstOrDefaultAsync())!;
        }

        public IQueryable<GetSubjectResponse> GetSubjectsListResponse()
        {
            return _dbContext.Subjects.AsNoTracking().Join(_classRepository.GetClassInfoIQueryable(), x => x.ClassId, x => x.Id, (S, C) => new GetSubjectResponse
            {
                Id = S.Id,
                Name = S.Name,
                ClassInfo = C.ClassInfo
            });
        }

        public async Task<List<GetSubjectResponse>> GetSubjectsListAsync()
        {
            return await GetSubjectsListResponse().ToListAsync();
        }
        #endregion
    }
}