using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Services;
using Dance = DanceParties.Interfaces.BusinessModels.Dance;
using DanceEntity = DanceParties.DataEntities.Dance;

namespace DanceParties.BusinessLogic
{
    public class DanceService : IDanceService
    {
        private readonly DancePartiesContext _dataContext;

        public DanceService(DancePartiesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Dance> GetDance(int id)
        {
            var entity = await _dataContext.Dance.SingleOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                throw new NotExistsException("Unknown dance id");
            }

            return ToModel(entity);
        }

        public Task<List<Dance>> GetDances()
        {
            var entities = _dataContext.Dance.Select(ToModel).ToList();
            return Task.FromResult(entities);
        }

        private Dance ToModel(DanceEntity entity)
        {
            return new Dance
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
