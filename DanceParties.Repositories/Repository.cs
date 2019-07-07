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
    public abstract class Repository<T, TModel> : IRepository<T> 
        where T : class
        where TModel : class
    {
        protected readonly DancePartiesContext _dbContext;

        protected abstract Func<T, TModel> Mapping { get; }

        public Repository(DancePartiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return FindAll()
                .Where(expression);
        }

        public virtual void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
