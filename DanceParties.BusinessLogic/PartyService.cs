using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanceParties.Interfaces.Services;
using Party = DanceParties.Interfaces.BusinessModels.Party;
using PartyEntity = DanceParties.DataEntities.Party;
using DanceParties.Interfaces.Repositories;
using AutoMapper;

namespace DanceParties.BusinessLogic
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;
        private readonly IMapper _mapper;

        public PartyService(IPartyRepository partyRepository, IMapper mapper)
        {         
            _partyRepository = partyRepository;
            _mapper = mapper;
        }

        public async Task<Party> GetParty(int id)
        {
            var entity = await GetEntity(id);
            var model = ToModel(entity);
            return model;
        }

        public async Task<List<Party>> GetParties()
        {
            var entities = await _partyRepository.GetAllAsync();
            return entities.Select(ToModel).ToList();
        }

        public async Task<Party> AddParty(Party party)
        {
            var entity = ToEntity(party);
            await _partyRepository.CreateAsync(entity);
            var model = await GetParty(entity.Id);
            return model;
        }    

        public async Task EditParty(int id, Party party)
        {
            var entity = await GetEntity(id);
            entity.LocationId = party.LocationId;
            entity.DanceId = party.DanceId;
            entity.Name = party.Name;
            entity.Start = party.Start;
            await _partyRepository.UpdateAsync(entity);
        }

        public async Task DeleteParty(int id)
        {
            await _partyRepository.DeleteAsync(id);
        }

        private async Task<PartyEntity> GetEntity(int id)
        {
            return await _partyRepository.GetAsync(id);
        }

        private Party ToModel(PartyEntity entity)
        {
            return _mapper.Map<Party>(entity);
        } 

        private PartyEntity ToEntity(Party model)
        {
            return _mapper.Map<PartyEntity>(model);
        }  
    }
}
