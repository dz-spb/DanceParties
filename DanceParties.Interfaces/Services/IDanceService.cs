using DanceParties.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.Services
{
    public interface IDanceService
    {
        Dance GetDance(int id);

        List<Dance> GetDances();
    }
}
