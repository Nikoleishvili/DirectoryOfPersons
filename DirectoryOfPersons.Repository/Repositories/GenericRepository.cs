using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Application.Interfaces.Repositories;
using DirectoryOfPersons.Domain.Interfaces;
using DirectoryOfPersons.Persistance.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Repository.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        protected ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        internal GenericRepository(ApplicationDbContext entity)
        {
            _context = entity;
            _dbSet = entity.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
            return query;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task DeleteAsync<TParameter>(TParameter Id)
        {
            var item = await _context.Set<TEntity>().FindAsync(Id);
            if (item is IDeletable)
            {
                var data = item as IDeletable;
                data.DateDeleted = DateTime.Now;
            }
            else
            {
                throw new Exception("Error during delete: Item can not be deleted!");
            }
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
