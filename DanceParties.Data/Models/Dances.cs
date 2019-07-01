using System;
using System.Collections.Generic;

namespace DanceParties.Data.Models
{
    public partial class Dances
    {
        public Dances()
        {
            Parties = new HashSet<Parties>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parties> Parties { get; set; }
    }
}
