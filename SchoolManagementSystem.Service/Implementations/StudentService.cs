using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public StudentService(IStudentRepository studentRepository, IPersonRepository personRepository)
        {
            _studentRepository = studentRepository;
            _personRepository = personRepository;
        }

        #endregion

        #region Handles Functions
        public Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id)
        {
            return _studentRepository.GetStudentByIdAsync(Id);
        }

        public IQueryable<GetStudentResponse> GetStudentsListResponse(string StudentNumber, string FullName, bool? Gender, int SectionId, int ClassID, int LevelId, int YearOfLevelId, int GuardianId, bool? IsActive)
        {
            return _studentRepository.GetStudentsListResponse(StudentNumber, FullName, Gender, SectionId, ClassID, LevelId, YearOfLevelId, GuardianId, IsActive);
        }

        public IQueryable<Student> GetStudentsListIQueryable()
        {
            return _studentRepository.GetStudentsListIQueryable();
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _studentRepository.GetTableAsNoTracking().AnyAsync(D => D.Id == Id);
        }

        public async Task<bool> IsStudentNumberExistAsync(string StudentNumber)
        {
            return await _studentRepository.GetTableAsNoTracking().AnyAsync(D => D.StudentNumber == StudentNumber);
        }

        public async Task<int> CreateStudentAsync(Student student)
        {
            try
            {
                await _studentRepository.AddAsync(student);
                return student.Id;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<bool> DeleteStudentAsync(int Id)
        {
            return await _studentRepository.DeleteStudentAsync(Id);
        }

        public async Task<bool> UpdateStudentAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsActive = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null)
        {
            var Transaction = _studentRepository.BeginTransaction();

            if (!_studentRepository.UpdateStudentByQuery(PersonId, SectionId, GuardianId, IsActive) || !_personRepository.UpdatePersonByQuery(PersonId, FirstName, LastName, Gender, DateOfBirth, null, null, Address, ImagePath))
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
