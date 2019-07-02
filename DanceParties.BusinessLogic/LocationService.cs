using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.Data.Models;
using DanceParties.Interfaces.Services;
using Location = DanceParties.Interfaces.BusinessModels.Location;
using LocationEntity = DanceParties.Data.Models.Location;

namespace LocationParties.BusinessLogic
{
    public class LocationService : ILocationService
    {
        private readonly DancePartiesContext _dataContext;

        public LocationService(DancePartiesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Location> GetLocation(int id)
        {
            var entity = await _dataContext.Location.SingleOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                throw new BusinessException("Unknown dance id");
            }

            return new Location
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Task<List<Location>> GetLocations()
        {
            var entities = _dataContext.Location.Select(ToDto).ToList();
            return Task.FromResult(entities);
        }

        private Location ToDto(LocationEntity entity)
        {
            return new Location
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
