using System.Linq;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Repositories;

namespace DanceParties.Repositories
{
    public class DanceRepository : Repository<Dance>
    {
        public DanceRepository(DancePartiesContext dataContext) : base(dataContext)
        {        
        } 

        protected override IQueryable<Dance> FindAll()
        {
            return _dbContext.Set<Dance>()
                .AsNoTracking();
        }  
    }
}
