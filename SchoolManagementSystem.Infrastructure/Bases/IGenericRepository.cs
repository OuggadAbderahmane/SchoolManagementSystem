using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolManagementSystem.Infrastructure.Bases
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> DeleteRangeAsync(ICollection<T> entities);
        int DeleteRange(ICollection<T> entities);

        Task<T?> GetByIdAsync(int id);
        T? GetById(int id);

        Task<int> SaveChangesAsync();
        int SaveChanges();

        IDbContextTransaction BeginTransaction();
        void Commit();
        void Rollback();

        IQueryable<T> GetTableAsTracking();
        IQueryable<T> GetTableAsNoTracking();

        Task<int> AddAsync(T entity);
        int Add(T entity);

        Task<int> AddRangeAsync(ICollection<T> entities);
        int AddRange(ICollection<T> entities);

        Task<int> UpdateAsync(T entity);
        int Update(T entity);

        Task<int> UpdateRangeAsync(ICollection<T> entities);
        int UpdateRange(ICollection<T> entities);

        Task<int> DeleteAsync(T entity);
        int Delete(T entity);
    }
}
