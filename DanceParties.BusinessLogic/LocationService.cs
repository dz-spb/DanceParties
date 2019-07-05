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

namespace DanceParties.BusinessLogic
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
            var entity = await _dataContext.Location
                .Include(l => l.City)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                throw new NotExistsException("Unknown dance id");
            }

            return ToModel(entity);
        }   

        public Task<List<Location>> GetLocations()
        {
            var entities = _dataContext.Location
                .Include(l => l.City)
                .Select(ToModel)
                .ToList();
            return Task.FromResult(entities);
        } 

        private Location ToModel(LocationEntity entity)
        {
            return new Location
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                CityId = entity.City.Id
            };
        } 
    }
}
