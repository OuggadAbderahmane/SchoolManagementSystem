using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.HelperClass;
using System.Text;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly IHelperClass _helperClass;
        #endregion

        #region Constructors
        public PersonRepository(AppDbContext dbContext, IHelperClass helperClass)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _helperClass = helperClass;
        }
        #endregion

        #region Handles Functions
        public IQueryable<Person> GetPeopleListIQueryable()
        {
            return _dbContext.People.AsNoTracking();
        }

        public async Task<List<GetPersonResponse>> GetPeopleListResponseAsync()
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return await _dbContext.People.AsNoTracking().Select(S =>
                                            new GetPersonResponse
                                            {
                                                Id = S.Id,
                                                NationalCardNumber = S.NationalCardNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? "Male" : "Female",
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                            }).ToListAsync();
        }

        public async Task<GetPersonResponse> GetPersonByIdAsync(int Id)
        {
            var url = _helperClass.GetSchemeHost() + '/';
            return (await _dbContext.People.AsNoTracking().Where(S => S.Id == Id).Select(S =>
                                            new GetPersonResponse
                                            {
                                                Id = S.Id,
                                                NationalCardNumber = S.NationalCardNumber,
                                                FirstName = S.FirstName,
                                                LastName = S.LastName,
                                                Gender = S.Gender ? "Male" : "Female",
                                                ImagePath = S.ImagePath != null ? url + S.ImagePath : null,
                                            }).FirstOrDefaultAsync())!;
        }

        public bool UpdatePersonByQuery(int PersonId, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Email = null, string? Phone = null, string? Address = null, string? ImagePath = null)
        {
            if (NationalCardNumber == null &&
                FirstName == null &&
                LastName == null &&
                Gender == null &&
                DateOfBirth == null &&
                Email == null &&
                Phone == null &&
                Address == null &&
                ImagePath == null)
                return true;
            var parameters = new List<SqlParameter>();
            var query = new StringBuilder("UPDATE [dbo].[People] SET ");

            if (NationalCardNumber != null)
            {
                query.Append("NationalCardNumber = @NationalCardNumber, ");
                parameters.Add(new SqlParameter("@NationalCardNumber", NationalCardNumber));
            }
            if (FirstName != null)
            {
                query.Append("FirstName = @FirstName, ");
                parameters.Add(new SqlParameter("@FirstName", FirstName));
            }
            if (LastName != null)
            {
                query.Append("LastName = @LastName, ");
                parameters.Add(new SqlParameter("@LastName", LastName));
            }
            if (Gender != null)
            {
                query.Append("Gender = @Gender, ");
                parameters.Add(new SqlParameter("@Gender", Gender));
            }
            if (DateOfBirth != null)
            {
                query.Append("DateOfBirth = @DateOfBirth, ");
                parameters.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
            }
            if (Email != null)
            {
                query.Append("Email = @Email, ");
                parameters.Add(new SqlParameter("@Email", Email));
            }
            if (Phone != null)
            {
                query.Append("Phone = @Phone, ");
                parameters.Add(new SqlParameter("@Phone", Phone));
            }
            if (Address != null)
            {
                query.Append("Address = @Address, ");
                parameters.Add(new SqlParameter("@Address", Address));
            }
            if (ImagePath != null)
            {
                query.Append("ImagePath = @ImagePath ");
                parameters.Add(new SqlParameter("@ImagePath", ImagePath));
            }

            // Remove the trailing comma and space
            if (query[query.Length - 2] == ',')
            {
                query.Remove(query.Length - 2, 2);
            }

            query.Append(" WHERE Id = @PersonId");
            parameters.Add(new SqlParameter("@PersonId", PersonId));
            try
            {
                _dbContext.Database.ExecuteSqlRaw(query.ToString(), parameters.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

}
