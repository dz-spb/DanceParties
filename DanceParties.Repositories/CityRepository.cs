using System.Linq;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Repositories;

namespace DanceParties.Repositories
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(DancePartiesContext dataContext) : base(dataContext)
        {        
        } 

        protected override IQueryable<City> FindAll()
        {
            return _dbContext.Set<City>()
                .AsNoTracking();
        }  
    }
}
