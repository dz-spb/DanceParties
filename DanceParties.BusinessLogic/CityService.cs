using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.Interfaces.Services;
using City = DanceParties.Interfaces.BusinessModels.City;
using CityEntity = DanceParties.DataEntities.City;
using DanceParties.DataEntities;
using AutoMapper;
using DanceParties.Interfaces.Repositories;

namespace DanceParties.BusinessLogic
{
    public class CityService : Service<CityEntity, City>
    {
        public CityService(IRepository<CityEntity> cityRepository, IMapper mapper)
               : base(cityRepository, mapper)
        {
        }

        public override async Task Edit(int id, City location)
        {
            var entity = await GetEntity(id);
            entity.Name = location.Name;       
            await _repository.UpdateAsync(entity);
        }
    }
}
