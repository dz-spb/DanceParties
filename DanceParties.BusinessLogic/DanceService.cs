using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.Data.Models;
using DanceParties.Interfaces.Services;
using Dance = DanceParties.Interfaces.BusinessModels.Dance;
using DanceEntity = DanceParties.Data.Models.Dance;

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
                throw new BusinessException("Unknown dance id");
            }

            return new Dance
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Task<List<Dance>> GetDances()
        {
            var entities = _dataContext.Dance.Select(ToDto).ToList();
            return Task.FromResult(entities);
        }

        private Dance ToDto(DanceEntity entity)
        {
            return new Dance
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
