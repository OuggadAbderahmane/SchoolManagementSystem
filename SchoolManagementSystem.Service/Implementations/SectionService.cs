using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class SectionService : ISectionService
    {
        #region Fields
        private readonly ISectionRepository _sectionRepository;
        #endregion

        #region Constructors
        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<GetSectionResponse> GetSectionByIdAsync(int Id)
        {
            return await _sectionRepository.GetSectionByIdAsync(Id);
        }

        public IQueryable<GetSectionResponse> GetSectionsListResponse()
        {
            return _sectionRepository.GetSectionsListResponse();
        }

        public IQueryable<Section> GetSectionsListIQueryable()
        {
            return _sectionRepository.GetSectionsListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _sectionRepository.GetTableAsNoTracking().AnyAsync(S => S.Id == Id);
        }

        public async Task<bool> UpdateSectionAsync(Section section)
        {
            var UpdateStudent = _sectionRepository.GetTableAsNoTracking().Single(S => S.Id == section.Id);
            if (section.Name != null) UpdateStudent.Name = section.Name;
            if (section.ClassId != 0) UpdateStudent.ClassId = section.ClassId;
            return (await _sectionRepository.UpdateAsync(UpdateStudent) != 0);
        }

        public async Task<int> CreateSectionAsync(Section section)
        {
            section.Name = section.Name.ToUpper();
            try
            {
                await _sectionRepository.AddAsync(section);
                return section.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<List<GetSectionResponse>> GetSectionsListAsync(int? LevelId, int? YearOfLevelId, int? ClassId)
        {
            return await _sectionRepository.GetSectionsListAsync(LevelId, YearOfLevelId, ClassId);
        }

        public async Task<bool> IsExistAsync(string? SectionName, int? ClassId, int? Id = null)
        {
            if (Id == null)
                return await _sectionRepository.GetTableAsNoTracking().AnyAsync(S => S.Name.ToUpper().Equals(SectionName!.ToUpper()) && S.ClassId == ClassId);

            var Query = _sectionRepository.GetTableAsNoTracking().First(x => x.Id == Id);
            if (SectionName != null) SectionName = Query.Name;
            if (ClassId != null) ClassId = Query.ClassId;

            return await _sectionRepository.GetTableAsNoTracking().AnyAsync(S => S.Name.ToUpper().Equals(SectionName!.ToUpper()) && S.ClassId == ClassId && S.Id != Id);
        }

        public async Task<int> DeleteByIdAsync(int Id)
        {
            return await _sectionRepository.GetTableAsNoTracking().Where(x => x.Id == Id).ExecuteDeleteAsync();
        }
        #endregion
    }
}
