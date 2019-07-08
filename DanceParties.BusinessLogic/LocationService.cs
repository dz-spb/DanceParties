using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Services;
using Location = DanceParties.Interfaces.BusinessModels.Location;
using LocationEntity = DanceParties.DataEntities.Location;
using DanceParties.Interfaces.Repositories;
using AutoMapper;
using DanceParties.Interfaces.BusinessModels;

namespace DanceParties.BusinessLogic
{
    public class LocationService : Service<LocationEntity, Location>
    {    
        public LocationService(IRepository<LocationEntity> locationRepository, IMapper mapper)
             : base(locationRepository, mapper)
        {
        }  

        public override async Task Edit(int id, Location location)
        {
            var entity = await GetEntity(id);
            entity.Name = location.Name;
            entity.Address = location.Address;
            entity.CityId = location.CityId;
            await _repository.UpdateAsync(entity);
        }
    }
}
