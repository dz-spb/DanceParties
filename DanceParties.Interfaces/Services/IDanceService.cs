using DanceParties.Interfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Services
{
    public interface IDanceService
    {
        Task<Dance> GetDance(int id);

        Task<List<Dance>> GetDances();
    }
}
