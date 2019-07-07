using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Repositories;
using DanceParties.DataEntities;
using DanceParties.Interfaces.BusinessModels;
using DanceParties.Interfaces.Exceptions;
using System;
using System.Collections.Generic;

namespace DanceParties.Repositories
{
    public abstract class Repository<T> where T : class
    {
        protected readonly DancePartiesContext _dbContext;

        public Repository(DancePartiesContext dbContext)
        {
            _dbContext = dbContext;
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
