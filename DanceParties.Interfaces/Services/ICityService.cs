using DanceParties.Interfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Services
{
    public interface ICityService
    {
        Task<City> GetCity(int id);

        Task<List<City>> GetCities();
    }
}
