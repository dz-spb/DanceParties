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

namespace DanceParties.BusinessLogic
{
    public class CityService : ICityService
    {
        private readonly DancePartiesContext _dataContext;

        public CityService(DancePartiesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<City> GetCity(int id)
        {
            var entity = await _dataContext.City.SingleOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                throw new NotExistsException("Unknown city id");
            }

            return ToModel(entity);
        }

        public Task<List<City>> GetCities()
        {
            var entities = _dataContext.City.Select(ToModel).ToList();
            return Task.FromResult(entities);
        }

        private City ToModel(CityEntity entity)
        {
            return new City
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
