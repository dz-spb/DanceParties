using DanceParties.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Repositories
{
    public interface IPartyRepository : IRepository<Party>
    {
        Task<IEnumerable<Party>> GetAllAsync();
        Task<Party> GetAsync(int id);
        Task CreateAsync(Party party);
        Task UpdateAsync(Party party);
        Task DeleteAsync(int id);
    }
}
