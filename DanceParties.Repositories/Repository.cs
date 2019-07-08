using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Exceptions;
using System.Collections.Generic;

namespace DanceParties.Repositories
{
    public abstract class Repository<T> where T : class, IEntity
    {
        protected readonly DancePartiesContext _dbContext;

        public Repository(DancePartiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var party = await FindByCondition(o => o.Id == id)
                .SingleOrDefaultAsync();

            if (party == null)
            {
                throw new NotExistsException();
            }

            return party;
        }

        public async Task CreateAsync(T entity)
        {
            Create(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Delete(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }

        protected virtual IQueryable<T> FindAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        protected virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return FindAll()
                .Where(expression);
        }

        protected virtual void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        protected virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        protected virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        protected async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
