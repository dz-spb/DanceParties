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
    public class PartyRepository : Repository<PartyEntity>, IRepository<PartyEntity>
    {
        public PartyRepository(DancePartiesContext dataContext) : base(dataContext)
        {        
        }

        public async Task<IEnumerable<PartyEntity>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<PartyEntity> GetAsync(int id)
        {
            var party = await FindByCondition(o => o.Id == id)
                .SingleOrDefaultAsync();

            if (party == null)
            {
                throw new NotExistsException();
            }

            return party;
        } 

        protected override IQueryable<PartyEntity> FindAll()
        {
            return _dbContext.Set<PartyEntity>()
                .AsNoTracking()
                .Include(p => p.Dance)
                .Include(p => p.Location)
                .ThenInclude(l => l.City);
        }

        public async Task CreateAsync(PartyEntity entity)
        {
            Create(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(PartyEntity entity)
        {
            Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(PartyEntity entity)
        {
            Delete(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }
    }
}
