using System.Linq;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Repositories;
using LocationEntity = DanceParties.DataEntities.Location;

namespace DanceParties.Repositories
{
    public class LocationRepository : Repository<LocationEntity>
    {
        public LocationRepository(DancePartiesContext dataContext) : base(dataContext)
        {        
        } 

        protected override IQueryable<LocationEntity> FindAll()
        {
            return _dbContext.Set<LocationEntity>()
                .AsNoTracking()
                .Include(l => l.City);                
        }  
    }
}
