using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Interfaces.Repositories;
using DanceParties.Interfaces.Exceptions;
using PartyEntity = DanceParties.DataEntities.Party;

namespace DanceParties.Repositories
{
    public class PartyRepository : Repository<PartyEntity>
    {
        public PartyRepository(DancePartiesContext dataContext) : base(dataContext)
        {        
        } 

        protected override IQueryable<PartyEntity> FindAll()
        {
            return _dbContext.Set<PartyEntity>()
                .AsNoTracking()
                .Include(p => p.Dance)
                .Include(p => p.Location)
                .ThenInclude(l => l.City);
        }  
    }
}
