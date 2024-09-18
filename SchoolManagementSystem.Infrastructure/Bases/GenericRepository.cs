using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Bases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handles Functions
        public virtual int Add(T entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int AddRange(ICollection<T> entities)
        {
            _dbContext.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public virtual int Delete(T entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int DeleteRange(ICollection<T> entities)
        {
            _dbContext.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteRangeAsync(ICollection<T> entities)
        {
            _dbContext.RemoveRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetTableAsNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public virtual int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int Update(T entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int UpdateRange(ICollection<T> entities)
        {
            _dbContext.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.UpdateRange(entities);
            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
