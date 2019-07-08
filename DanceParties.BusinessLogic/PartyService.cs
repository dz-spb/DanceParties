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
using DanceParties.Interfaces.BusinessModels;

namespace DanceParties.BusinessLogic
{
    public class PartyService : Service<PartyEntity, Party>
    {
        public PartyService(IRepository<PartyEntity> partyRepository, IMapper mapper) 
            : base(partyRepository, mapper)
        {         
        }

        public override async Task Edit(int id, Party party)
        {
            var entity = await GetEntity(id);
            entity.LocationId = party.LocationId;
            entity.DanceId = party.DanceId;
            entity.Name = party.Name;
            entity.Start = party.Start;
            await _repository.UpdateAsync(entity);
        }      
    }
}
