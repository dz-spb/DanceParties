using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.BusinessModels
{
    public class Party
    {
        public int Id { get; set; }

        public int DanceId { get; set; }

        public string Dance { get; set; }

        public string Name { get; set; }      

        public DateTimeOffset Start { get; set; }

        public int LocationId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public string City { get; set; }
    }
}
