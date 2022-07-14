using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Infrasturcture
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ShopsRUsDbContext _appContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ShopsRUsDbContext appContext)
        {
            _appContext = appContext;
            _dbSet = appContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity.GetType().GetProperty("IsDeleted") == null)
            {
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, true);
                Update(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }
    }
}
