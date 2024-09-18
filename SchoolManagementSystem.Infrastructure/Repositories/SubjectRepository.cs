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
            return (await _dbContext.Subjects.AsNoTracking().Select(x => new GetSubjectResponse
            {
                Id = x.Id,
                Name = x.Name,
                ClassInfo = _classRepository.GetClassInfo(x.ClassId).Result
            }).FirstOrDefaultAsync(x => x.Id == Id))!;
        }

        public IQueryable<GetSubjectResponse> GetSubjectsListResponse()
        {
            return _dbContext.Subjects.AsNoTracking().Select(x => new GetSubjectResponse
            {
                Id = x.Id,
                Name = x.Name,
                ClassInfo = _classRepository.GetClassInfo(x.ClassId).Result
            });
        }
        public async Task<List<GetSubjectResponse>> GetSubjectsListAsync()
        {
            return await _dbContext.Subjects.AsNoTracking().Select(x => new GetSubjectResponse
            {
                Id = x.Id,
                Name = x.Name,
                ClassInfo = _classRepository.GetClassInfo(x.ClassId).Result
            }).ToListAsync();
        }
        #endregion
    }
}