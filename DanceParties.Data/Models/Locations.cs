using System;
using System.Collections.Generic;

namespace DanceParties.Data.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Parties = new HashSet<Parties>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Parties> Parties { get; set; }
    }
}
