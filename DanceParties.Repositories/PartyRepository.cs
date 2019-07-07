using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.DataEntities;
using DanceParties.Repositories;
using DanceParties.Interfaces.BusinessModels;
using DanceParties.Interfaces.Repositories;
using Party = DanceParties.Interfaces.BusinessModels.Party;
using PartyEntity = DanceParties.DataEntities.Party;
using DanceParties.Interfaces.Exceptions;

namespace DanceParties.Repositories
{
    public class PartyRepository : Repository<PartyEntity, Party>, IPartyRepository
    {   
        protected override Func<PartyEntity, Party> Mapping
        {
            get { return ToModel2; }
        }

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

        public override IQueryable<PartyEntity> FindAll()
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

        private Party ToModel(PartyEntity entity)
        {
            return new Party
            {
                Id = entity.Id,
                Name = entity.Name,
                LocationId = entity.LocationId,
                DanceId = entity.DanceId,
                Start = entity.Start
            };
        }

        private static Party ToModel2(PartyEntity entity)
        {
            return new Party
            {
                Id = entity.Id,
                Name = entity.Name,
                LocationId = entity.LocationId,
                DanceId = entity.DanceId,
                Start = entity.Start
            };
        }

    }
}
