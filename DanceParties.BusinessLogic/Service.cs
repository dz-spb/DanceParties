using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DanceParties.DataEntities;
using DanceParties.Interfaces;
using DanceParties.Interfaces.Repositories;
using DanceParties.Interfaces.Services;

namespace DanceParties.BusinessLogic
{
    public abstract class Service<TEntity, TModel> : IService<TModel>
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TModel> Get(int id)
        {
            var entity = await GetEntity(id);
            var model = ToModel(entity);
            return model;
        }

        public virtual async Task<List<TModel>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(ToModel).ToList();
        }

        public virtual async Task<TModel> Add(TModel dance)
        {
            var entity = ToEntity(dance);
            await _repository.CreateAsync(entity);
            var model = await Get(entity.Id);
            return model;
        }

        public abstract Task Edit(int id, TModel dance);

        public virtual async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        protected virtual async Task<TEntity> GetEntity(int id)
        {
            return await _repository.GetAsync(id);
        }

        protected virtual TModel ToModel(TEntity entity)
        {
            return _mapper.Map<TModel>(entity);
        }

        protected TEntity ToEntity(TModel model)
        {
            return _mapper.Map<TEntity>(model);
        }
    }
}
