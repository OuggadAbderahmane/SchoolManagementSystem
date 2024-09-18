using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Wrappers
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            where T : class
        {
            if (source == null)
            {
                throw new Exception("Empty");
            }

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            if (count == 0) return PaginatedResult<T>.Success([], count, pageNumber, pageSize);
            List<T> items;
            if (pageNumber * pageSize <= count)
                items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            else
            {
                pageNumber = (int)double.Ceiling(count / (double)pageSize);
                items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
