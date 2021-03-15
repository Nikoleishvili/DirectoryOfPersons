using DirectoryOfPersons.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Repository.Extensions
{
    public static class PagingExtension
    {
        public static async Task<PagedData<T>> GetPagedData<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await query.CountAsync(cancellationToken);
            var list = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var data = new PagedData<T>()
            {
                Data = list,
                TotalItemCount = count,
                Page = pageNumber,
                Offset = pageSize,
                PageCount = count % pageSize == 0 ? count / pageSize : count / pageSize + 1
            };
            return data;
        }
    }
}
