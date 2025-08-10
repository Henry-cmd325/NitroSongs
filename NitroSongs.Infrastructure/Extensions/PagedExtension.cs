using Microsoft.EntityFrameworkCore;
using NitroSongs.Common.Common;

namespace NitroSongs.Infrastructure.Extensions
{
    public static class PagedExtension
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> queryable, int page, int size)
        {
            var totalCount = queryable.Count();
            var items = await queryable.Skip((page - 1) * size).Take(size).ToListAsync();

            var pagedResult = new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = size
            };

            return pagedResult;
        } 
    }
}
