using System.Collections.Generic;
using System.Threading.Tasks;
using DanceParties.DataEntities;

namespace DanceParties.Interfaces.Repositories
{
    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAllAsync();
        Task<Party> GetAsync(int id);
        Task CreateAsync(Party party);
        Task UpdateAsync(Party party);
        Task DeleteAsync(Party party);
        Task DeleteAsync(int id);
    }
}
