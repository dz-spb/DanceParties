using System;
using System.Collections.Generic;

namespace DanceParties.DataEntities
{
    public partial class Location
    {
        public Location()
        {
            Party = new HashSet<Party>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Party> Party { get; set; }
    }
}
