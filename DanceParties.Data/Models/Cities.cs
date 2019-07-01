using System;
using System.Collections.Generic;

namespace DanceParties.Data.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Locations> Locations { get; set; }
    }
}
