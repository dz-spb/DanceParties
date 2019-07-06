using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Exceptions;
using DanceParties.Data.Models;
using DanceParties.Interfaces.Services;
using Party = DanceParties.Interfaces.BusinessModels.Party;
using PartyEntity = DanceParties.Data.Models.Party;

namespace DanceParties.BusinessLogic
{
    public class PartyService : IPartyService
    {
        private readonly DancePartiesContext _dataContext;

        public PartyService(DancePartiesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Party> GetParty(int id)
        {
            var entity = await GetEntity(id);
            var model = ToModel(entity);
            return model;
        }     

        public async Task<Party> AddParty(Party party)
        {
            var entity = ToEntity(party);
            _dataContext.Party.Add(entity);
            await _dataContext.SaveChangesAsync();
            var createdEntity = await GetEntity(entity.Id);
            var model = ToModel(createdEntity);
            return model;
        }    

        public async Task EditParty(int id, Party party)
        {
            var entity = await GetEntity(id);
            entity.LocationId = party.LocationId;
            entity.DanceId = party.DanceId;
            entity.Name = party.Name;
            entity.Start = party.Start;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteParty(int id)
        {
            var entity = await GetEntity(id);
            _dataContext.Party.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public Task<List<Party>> GetParties()
        {
            var entities = _dataContext.Party
                .Include(p => p.Location)
                .Include(p => p.Dance)
                .Select(ToModel)
                .ToList();
            return Task.FromResult(entities);
        }

        private async Task<PartyEntity> GetEntity(int id)
        {
            var entity = await _dataContext.Party
                .Include(p => p.Location)
                .ThenInclude(l => l.City)
                .Include(p => p.Dance)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                throw new NotExistsException("Unknown party id");
            }

            return entity;
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

        private PartyEntity ToEntity(Party model)
        {
            return new PartyEntity
            {
                Id = model.Id,
                LocationId = model.LocationId,
                DanceId = model.DanceId,
                Name = model.Name,
                Start = model.Start
            };
        }  
    }
}
