using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class TeacherService : ITeacherService
    {
        #region Fields
        private readonly ITeacherRepository _teacherRepository;
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public TeacherService(ITeacherRepository teacherRepository, IPersonRepository personRepository)
        {
            _teacherRepository = teacherRepository;
            _personRepository = personRepository;
        }

        #endregion

        #region Handles Functions
        public Task<GetAllTeacherInfoResponse> GetTeacherByIdAsync(int Id)
        {
            return _teacherRepository.GetTeacherByIdAsync(Id);
        }

        public IQueryable<GetTeacherResponse> GetTeachersListResponse(string NationalCardNumber, string FirstName, string LastName, bool? Gender, bool? PermanentWork)
        {
            return _teacherRepository.GetTeachersListResponse(NationalCardNumber, FirstName, LastName, Gender, PermanentWork);
        }

        public IQueryable<Teacher> GetTeachersListIQueryable()
        {
            return _teacherRepository.GetTeachersListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _teacherRepository.GetTableAsNoTracking().AnyAsync(D => D.Id == Id);
        }

        public async Task<bool> CreateTeacherAsync(int PersonId, decimal Salary, bool IsPermanentWorkAvtive)
        {
            try
            {
                return await _teacherRepository.AddNewTeacherByPersonAsync(PersonId, Salary, IsPermanentWorkAvtive);
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> CreateTeacherAsync(Teacher teacher)
        {
            try
            {
                await _teacherRepository.AddAsync(teacher);
                return teacher.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<bool> DeleteTeacherAsync(int Id)
        {
            return await _teacherRepository.DeleteTeacherAsync(Id);
        }

        public async Task<bool> UpdateTeacherAsync(int PersonId, decimal? Salary = null, bool? IsPermanentWorkAvtive = null, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null, string? Email = null, string? Phone = null)
        {
            var Transaction = _teacherRepository.BeginTransaction();

            if (!_teacherRepository.UpdateTeacherByQuery(PersonId, Salary, IsPermanentWorkAvtive) || !_personRepository.UpdatePersonByQuery(PersonId, NationalCardNumber, FirstName, LastName, Gender, DateOfBirth, Email, Phone, Address, ImagePath))
            {
                await Transaction.RollbackAsync();
                return false;
            }

            Transaction.Commit();
            return true;

        }
        #endregion
    }
}
