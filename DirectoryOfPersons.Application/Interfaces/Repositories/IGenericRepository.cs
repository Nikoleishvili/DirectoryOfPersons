using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task DeleteAsync<TParameter>(TParameter Id);

        Task SaveAsync();
    }
}
