using DanceParties.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.Services
{
    public interface ILocationService
    {
        Location GetLocation(int id);

        List<Location> GetLocations();
    }
}
