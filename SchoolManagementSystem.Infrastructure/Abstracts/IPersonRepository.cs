using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        public Task<GetPersonResponse> GetPersonByIdAsync(int Id);
        public Task<List<GetPersonResponse>> GetPeopleListResponseAsync();
        public IQueryable<Person> GetPeopleListIQueryable();
        public bool UpdatePersonByQuery(int PersonId, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Email = null, string? Phone = null, string? Address = null, string? ImagePath = null);
    }
}
