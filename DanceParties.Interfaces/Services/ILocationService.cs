using DanceParties.Interfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation(int id);

        Task<List<Location>> GetLocations();
    }
}
