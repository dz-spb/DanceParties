using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.Filters
{
    public class PartyFilters
    {
        public DateTimeOffset Begin { get; set; }

        public DateTimeOffset End { get; set; }

        public string Name { get; set; }
    }
}
