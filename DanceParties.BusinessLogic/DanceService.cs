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
using DanceParties.Interfaces.Repositories;
using AutoMapper;

namespace DanceParties.BusinessLogic
{
    public class DanceService : Service<DanceEntity, Dance>
    {
        public DanceService(IRepository<DanceEntity> danceRepository, IMapper mapper)
            : base(danceRepository, mapper)
        {
        }
   
        public override async Task Edit(int id, Dance dance)
        {
            var entity = await GetEntity(id);
            entity.Name = dance.Name;
            await _repository.UpdateAsync(entity);
        }
    }
}
