using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Service.Abstracts;
using System.Text.RegularExpressions;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class PesronService : IPersonService
    {
        #region Fields
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public PesronService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Person> GetPeopleListIQueryable()
        {
            return _personRepository.GetPeopleListIQueryable();
        }

        public async Task<List<GetPersonResponse>> GetPeopleListResponseAsync()
        {
            return await _personRepository.GetPeopleListResponseAsync();
        }

        public async Task<GetPersonResponse> GetPersonByIdAsync(int Id)
        {
            return await _personRepository.GetPersonByIdAsync(Id);
        }

        public async Task<bool> IsIdExistAsync(int Id)
        {
            return await _personRepository.GetTableAsNoTracking().AnyAsync(D => D.Id == Id);
        }

        public Task<bool> EmailValidator(string email)
        {
            if (email == null)
                return Task.FromResult(false);
            return Task.FromResult(Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"));
        }

        public Task<bool> GenderValidator(string gender)
        {
            return Task.FromResult(gender.ToUpper() == "MALE" || gender.ToUpper() == "FEMALE");
        }

        public bool GetGenderValue(string gender)
        {
            return gender.ToUpper() == "MALE";
        }

        public Task<bool> PhoneValidator(string Phone)
        {
            if (Phone == null)
                return Task.FromResult(false);
            foreach (var item in Phone.Trim())
                if (!char.IsDigit(item))
                    return Task.FromResult(false);
            return Task.FromResult(true);
        }

        public async Task<bool> IsEmailExistAsync(string email, int? Id = null)
        {
            if (Id != null)
                return await _personRepository.GetTableAsNoTracking().AnyAsync(S => S.Email != null && S.Email.Equals(email) && S.Id != Id); ;
            return await _personRepository.GetTableAsNoTracking().AnyAsync(S => S.Email != null && S.Email.Equals(email));
        }

        public async Task<bool> IsNationalCardNumberExistAsync(string NationalCardNumber, int? Id = null)
        {
            if (Id != null)
                return await _personRepository.GetTableAsNoTracking().AnyAsync(S => S.NationalCardNumber == NationalCardNumber && S.Id != Id);
            return await _personRepository.GetTableAsNoTracking().AnyAsync(S => S.NationalCardNumber == NationalCardNumber);
        }
        #endregion
    }
}
