using DanceParties.Interfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanceParties.Interfaces.Repositories
{
    public interface IPartyRepository
    {
        IQueryable<Party> GetParties();
    }
}
