using DanceParties.Data.Models;
using DanceParties.Interfaces.BusinessModels;
using DanceParties.Interfaces.Filters;
using DanceParties.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Party = DanceParties.Interfaces.BusinessModels.Party;
using PartyEntity = DanceParties.Data.Models.Party;

namespace DanceParties.Data
{
    public class PartyRepository : IPartyRepository
    {
        private readonly DancePartiesContext _dataContext;

        public PartyRepository(DancePartiesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Party> GetParties()
        {
            var entities = _dataContext.Party
                         .Include(p => p.Location)
                         .Include(p => p.Dance)
                         .Select(ToModel);
            //.AsQueryable();

            var result = new AsyncEnumerableQuery<Party>(entities.Distinct());

            return result;
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
    }
}
