using DanceParties.Interfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Services
{
    public interface IPartyService
    {
        Task<Party> GetParty(int id);

        Task<List<Party>> GetParties();

        Task<Party> AddParty(Party party);

        Task EditParty(int id, Party party);

        Task DeleteParty(int id);
    }
}
