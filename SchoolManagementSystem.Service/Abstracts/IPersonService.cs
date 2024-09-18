using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IPersonService
    {
        public Task<GetPersonResponse> GetPersonByIdAsync(int Id);
        public Task<List<GetPersonResponse>> GetPeopleListResponseAsync();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> IsEmailExistAsync(string email, int? Id = null);
        public IQueryable<Person> GetPeopleListIQueryable();
        public Task<bool> EmailValidator(string email);
        public Task<bool> PhoneValidator(string Phone);
        public bool GetGenderValue(string gender);
        public Task<bool> GenderValidator(string gender);
        public Task<bool> IsNationalCardNumberExistAsync(string NationalCardNumber, int? Id = null);
    }
}
