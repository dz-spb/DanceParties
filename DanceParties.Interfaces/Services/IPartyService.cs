using DanceParties.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.Services
{
    public interface IPartyService
    {
        Party GetParty(int id);

        Party AddParty(Party party);

        Party EditParty(Party party);

        void DeleteParty(int id);

        List<Party> GetParties();
    }
}
